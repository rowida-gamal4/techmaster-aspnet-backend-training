using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        private readonly IEnrollmentService enrollmentService;

        public StudentService(AppDbContext context, ICurrentUserService currentUserService, IEnrollmentService enrollmentService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.enrollmentService = enrollmentService;
        }

        #region Task03 Special Methods
        public GeneralResponseDto<StudentDetailsResponse> GetMyProfile()
        {
            GeneralResponseDto<StudentDetailsResponse> response = new();
            var currentUserId = currentUserService.UserId;

            var currentUser = context.Users.FirstOrDefault(u => u.Id == currentUserId);
            if (currentUser is null)
            {
                response.Success = false;
                response.Message = "User not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            if (currentUser.StudentId == null)
            {
                response.Success = false;
                response.Message = "Student not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }
            var student = context.Students.FirstOrDefault(s => s.StudentId == currentUser.StudentId &&
            !s.IsDeleted);

            if (student is null)
            {
                response.Success = false;
                response.Message = "Student profile not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
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

            response.Success = true;
            response.Message = "Student profile retrieved successfully.";
            response.Data = detailsResponse;

            return response;
        }

        public GeneralResponseDto<StudentEnrollmentHistoryResponse> GetMyEnrollments()
        {
            GeneralResponseDto<StudentEnrollmentHistoryResponse> response = new();
            var currentStudentId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.StudentId).FirstOrDefault();

            if (currentStudentId == null)
            {
                response.Success = false;
                response.Message = "Student profile not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }
            var student = context.Students.Where(s => s.StudentId == currentStudentId.Value && !s.IsDeleted).Select(s => new StudentEnrollmentHistoryResponse
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Enrollments = s.Enrollments.Select(e => new StudentEnrollmentItemResponse
                {
                    EnrollmentId = e.EnrollmentId,
                    TrackId = e.TrainingTrackId,
                    TrackTitle = e.TrainingTrack.Title,
                    EnrollmentDate = e.EnrollmentDate,
                    Status = e.Status,
                    ProgressPercentage = e.ProgressPercentage,
                    FinalResult = e.FinalResult
                }).ToList()
            }).FirstOrDefault();

            if (student is null)
            {
                response.Success = false;
                response.Message = "Student not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            response.Success = true;
            response.Message = "Student enrollments retrieved successfully.";
            response.Data = student;

            return response;

        }

        public GeneralResponseDto<List<PaymentResponse>> GetMyPayments()
        {
            GeneralResponseDto<List<PaymentResponse>> response = new();
            var currentStudentId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.StudentId).FirstOrDefault();

            if (currentStudentId == null)
            {
                response.Success = false;
                response.Message = "Student profile not found.";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }
            var payments = context.Payments.Where(p => p.Enrollment.StudentId == currentStudentId.Value).Select(p => new PaymentResponse
            {
                PaymentId = p.PaymentId,
                EnrollmentId = p.EnrollmentId,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentDate = p.PaymentDate,
                PaymentStatus = p.PaymentStatus.ToString(),
                ReferenceNumber = p.ReferenceNumber
            }).ToList();

            response.Success = true;
            response.Message = "Payment history retrieved successfully.";
            response.Data = payments;

            return response;
        }


        public GeneralResponseDto<EnrollmentDetailsResponse> CreateStudentEnrollmentRequest(int trainingTrackId)
        {
            var studentId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.StudentId).FirstOrDefault();

            if (studentId == null)
            {
                return new GeneralResponseDto<EnrollmentDetailsResponse>
                {
                    Success = false,
                    Message = "Student profile not found.",
                    ErrorType = ErrorType.NotFound
                };
            }

            var request = new CreateEnrollmentRequest
            {
                StudentId = studentId.Value,
                TrainingTrackId = trainingTrackId,
                ProgressPercentage = 0
            };

            return enrollmentService.CreateEnrollment(request);
        }

        public GeneralResponseDto<StudentDetailsResponse> UpdateMyProfile(UpdateStudentMe request)
        {
            GeneralResponseDto<StudentDetailsResponse> responseDto = new();

            var studentId = context.Users.Where(u => u.Id == currentUserService.UserId).Select(u => u.StudentId).FirstOrDefault();

            if (studentId == null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student profile not found.";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }

            var student = context.Students.FirstOrDefault(s => s.StudentId == studentId.Value && !s.IsDeleted);

            if (student is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Student not found.";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }

            bool emailExists = context.Students.Any(s => !s.IsDeleted && s.StudentId != student.StudentId && s.Email.ToLower() == request.Email.ToLower());

            if (emailExists)
            {
                responseDto.Success = false;
                responseDto.Message = "Email already exists.";
                responseDto.ErrorType = ErrorType.Conflict;
                return responseDto;
            }

            student.FullName = request.FullName;
            student.Email = request.Email;
            student.PhoneNumber = request.PhoneNumber;
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
            responseDto.Message = "Profile updated successfully.";
            responseDto.Data = detailsResponse;

            return responseDto;
        }
        #endregion

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
                studentsQuery = studentsQuery.Where(s => s.Enrollments.Any(e => e.TrainingTrack.InstructorId == instructorId));
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