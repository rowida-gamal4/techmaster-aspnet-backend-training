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

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }


        // Queries 1 , 2, 3
        public GeneralResponseDto<PagedResult<StudentListItemResponse>> GetAllStudents(string? search, bool? isActive, bool includeDeleted = false, int pageNumber = 1, int pageSize = 10)
        {
            GeneralResponseDto<PagedResult<StudentListItemResponse>> response = new();

            if (pageNumber < 1)
            {
                response.Success = false;
                response.Message = "Page number must be greater than 0.";
                return response;
            }

            if (pageSize < 1 || pageSize > 50)
            {
                response.Success = false;
                response.Message = "Page size must be between 1 and 50.";
                return response;
            }

            var studentsQuery = context.Students.AsQueryable();

            if (!includeDeleted)
            {
                studentsQuery = studentsQuery.Where(s => !s.IsDeleted);
            }

            //Query 1 - Search Students
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                studentsQuery = studentsQuery.Where(s => s.FullName.ToLower().Contains(search) || s.Email.ToLower().Contains(search) || (s.PhoneNumber != null && s.PhoneNumber.ToLower().Contains(search)));
            }

            //Query 2 - Filter Students By Status
            if (isActive.HasValue)
            {
                studentsQuery = studentsQuery.Where(s => s.IsActive == isActive.Value);
            }

            int totalCount = studentsQuery.Count();

            // Query 3 - Paged Students List
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
            var student = context.Students.Where(s => !s.IsDeleted).FirstOrDefault(s => s.StudentId == id);

            if (student is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student not found";
                return responseDto;
            }
            else
            {

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
                responseDto.Message = "Student found successfully";
                responseDto.Data = detailsResponse;

            }

            return responseDto;
        }

        public GeneralResponseDto<StudentDetailsResponse> CreateStudent(CreateStudentRequest studentRequest)
        {
            GeneralResponseDto<StudentDetailsResponse> responseDto = new();
            if (context.Students.Any(s => s.Email == studentRequest.Email))
            {
                responseDto.Success = false;
                responseDto.Message = "Email already exists";
                return responseDto;
            }
            Student student = new()
            {
                FullName = studentRequest.FullName,
                Email = studentRequest.Email,
                PhoneNumber = studentRequest.PhoneNumber,
                IsActive = studentRequest.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            context.Students.Add(student);
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
            responseDto.Message = "Student created successfully";
            responseDto.Data = detailsResponse;

            return responseDto;

        }

        public GeneralResponseDto<StudentDetailsResponse> UpdateStudent(int id, UpdateStudentRequest studentRequest)
        {
            GeneralResponseDto<StudentDetailsResponse> responseDto = new();
            var student = context.Students.FirstOrDefault(s => s.StudentId == id);

            if (student is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student not found";
                return responseDto;
            }
            else
            {
                bool emailExists = context.Students.Any(s =>s.StudentId != id &&s.Email.ToLower() == studentRequest.Email.ToLower());

                if (emailExists)
                {
                    responseDto.Success = false;
                    responseDto.Message = "Email already exists.";
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