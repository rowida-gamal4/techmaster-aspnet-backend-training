using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;
        private readonly ICurrentUserService currentUserService;

        public StudentService(AppDbContext context, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }



        public GeneralResponseDto<PagedResult<StudentListItemResponse>> GetAllStudents(string? search, bool? isActive, bool includeDeleted = false, int pageNumber = 1, int pageSize = 10)
        {
            GeneralResponseDto<PagedResult<StudentListItemResponse>> response = new();

            if (pageNumber < 1)
            {
                response.Success = false;
                response.Message = "Page number must be greater than 0.";
                response.ErrorType = ErrorType.Validation;
                return response;
            }

            if (pageSize < 1 || pageSize > 50)
            {
                response.Success = false;
                response.Message = "Page size must be between 1 and 50.";
                response.ErrorType = ErrorType.Validation;
                return response;
            }

            var studentsQuery = context.Students.AsQueryable();

            //Instructor 
            if (currentUserService.Role == Role.Instructor)
            {
                var instructorId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.InstructorId).FirstOrDefault();

                if (instructorId == null)
                {
                    response.Success = false;
                    response.Message = "Instructor not found.";
                    response.ErrorType = ErrorType.NotFound;
                    return response;
                }
                studentsQuery = studentsQuery.Where(s =>s.Enrollments.Any(e => e.TrainingTrack.InstructorId == instructorId));
            }

            if (!includeDeleted)
            {
                studentsQuery = studentsQuery.Where(s => !s.IsDeleted);
            }


            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                studentsQuery = studentsQuery.Where(s => s.FullName.ToLower().Contains(search) || s.Email.ToLower().Contains(search) || (s.PhoneNumber != null && s.PhoneNumber.ToLower().Contains(search)));
            }


            if (isActive.HasValue)
            {
                studentsQuery = studentsQuery.Where(s => s.IsActive == isActive.Value);
            }

            int totalCount = studentsQuery.Count();


            var students = studentsQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(s => new StudentListItemResponse
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                IsActive = s.IsActive
            }).ToList();

            response.Success = true;
            response.Message = "Students retrieved successfully";
            response.Data = new PagedResult<StudentListItemResponse>
            {
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                PageNumber = pageNumber,
                PageSize = pageSize,
                Items = students
            };

            return response;
        }
        public GeneralResponseDto<StudentDetailsResponse> GetStudentById(int id)
        {
            GeneralResponseDto<StudentDetailsResponse> responseDto = new();

            var student = context.Students.FirstOrDefault(s => s.StudentId == id && !s.IsDeleted);

            if (student is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }

            StudentDetailsResponse detailsResponse = new()
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                IsActive = student.IsActive,
                CreatedAt = student.CreatedAt,
                UpdatedAt = student.UpdatedAt
            };

            var currentUserId = currentUserService.UserId;
            var currentUserRole = currentUserService.Role;

            //Admin 
            if (currentUserRole == Role.Admin)
            {
                responseDto.Success = true;
                responseDto.Message = "Student found successfully";
                responseDto.Data = detailsResponse;
                return responseDto;
            }

            //Student
            if (currentUserRole == Role.Student)
            {
                var currentUser = context.Users.FirstOrDefault(u => u.Id == currentUserId);
                if (currentUser?.StudentId != id)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to view this student.";
                    responseDto.ErrorType = ErrorType.Forbidden;
                    return responseDto;
                }

                responseDto.Success = true;
                responseDto.Message = "Student found successfully";
                responseDto.Data = detailsResponse;
                return responseDto;
            }

            //Instructor
            if (currentUserRole == Role.Instructor)
            {
                var instructor = context.Users.FirstOrDefault(u => u.Id == currentUserId);

                if (instructor?.InstructorId == null)
                {
                    responseDto.Success = false;
                    responseDto.Message = "Instructor not found.";
                    responseDto.ErrorType = ErrorType.NotFound;

                    return responseDto;
                }
                var allowed = context.Enrollments.Any(e => e.StudentId == id && e.TrainingTrack.InstructorId == instructor.InstructorId);

                if (!allowed)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to view this student.";
                    responseDto.ErrorType = ErrorType.Forbidden;

                    return responseDto;
                }
                responseDto.Success = true;
                responseDto.Message = "Student found successfully";
                responseDto.Data = detailsResponse;

                return responseDto;
            }
            responseDto.Success = false;
            responseDto.Message = "You are not allowed to view this student.";
            responseDto.ErrorType = ErrorType.Forbidden;

            return responseDto;

        }

        public GeneralResponseDto<StudentDetailsResponse> CreateStudent(CreateStudentRequest request)
        {
            GeneralResponseDto<StudentDetailsResponse> response = new();

            if (context.Students.Any(s => !s.IsDeleted && s.Email.ToLower() == request.Email.ToLower()))
            {
                response.Success = false;
                response.Message = "Email already exists.";
                response.ErrorType = ErrorType.Conflict;
                return response;
            }

            if (context.Users.Any(u => u.Email.ToLower() == request.Email.ToLower()))
            {
                response.Success = false;
                response.Message = "Email already exists.";
                response.ErrorType = ErrorType.Conflict;
                return response;
            }

            using var transaction = context.Database.BeginTransaction();

            try
            {
                Student student = new()
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    IsActive = request.IsActive,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow
                };

                context.Students.Add(student);
                context.SaveChanges();

                ApplicationUser user = new()
                {
                    FullName = student.FullName,
                    Email = student.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Role = Role.Student,
                    IsActive = student.IsActive,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    StudentId = student.StudentId,
                    InstructorId = null
                };

                context.Users.Add(user);
                context.SaveChanges();

                transaction.Commit();

                StudentDetailsResponse detailsResponse = new()
                {
                    StudentId = student.StudentId,
                    FullName = student.FullName,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    IsActive = student.IsActive,
                    CreatedAt = student.CreatedAt,
                    UpdatedAt = student.UpdatedAt
                };

                response.Success = true;
                response.Message = "Student and user account created successfully.";
                response.Data = detailsResponse;

                return response;
            }
            catch
            {
                transaction.Rollback();

                response.Success = false;
                response.Message = "Failed to create student.";
                response.ErrorType = ErrorType.Conflict;

                return response;
            }
        }

        public GeneralResponseDto<StudentDetailsResponse> UpdateStudent(int id, UpdateStudentRequest studentRequest)
        {
            GeneralResponseDto<StudentDetailsResponse> responseDto = new();
            var student = context.Students.FirstOrDefault(s => s.StudentId == id && !s.IsDeleted);

            if (student is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }
            else
            {
                bool emailExists = context.Students.Any(s => !s.IsDeleted && s.StudentId != id && s.Email.ToLower() == studentRequest.Email.ToLower());

                if (emailExists)
                {
                    responseDto.Success = false;
                    responseDto.Message = "Email already exists.";
                    responseDto.ErrorType = ErrorType.Conflict;
                    return responseDto;
                }
                student.FullName = studentRequest.FullName;
                student.Email = studentRequest.Email;
                student.IsActive = studentRequest.IsActive;
                student.PhoneNumber = studentRequest.PhoneNumber;
                student.UpdatedAt = DateTime.UtcNow;
                context.SaveChanges();

                StudentDetailsResponse detailsResponse = new()
                {
                    StudentId = student.StudentId,
                    FullName = student.FullName,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    IsActive = student.IsActive,
                    CreatedAt = student.CreatedAt,
                    UpdatedAt = student.UpdatedAt
                };

                responseDto.Success = true;
                responseDto.Message = "Student updated successfully";
                responseDto.Data = detailsResponse;

            }

            return responseDto;

        }

        GeneralResponseDto<bool> IStudentService.DeleteStudent(int id)
        {
            GeneralResponseDto<bool> responseDto = new();
            var student = context.Students.FirstOrDefault(s => s.StudentId == id);

            if (student is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student not found";
                responseDto.ErrorType = ErrorType.NotFound;
            }
            else
            {
                student.IsDeleted = true;
                student.DeletedAt = DateTime.UtcNow;
                context.SaveChanges();

                responseDto.Success = true;
                responseDto.Message = "Student deleted successfully";
            }
            return responseDto;

        }

    }
}