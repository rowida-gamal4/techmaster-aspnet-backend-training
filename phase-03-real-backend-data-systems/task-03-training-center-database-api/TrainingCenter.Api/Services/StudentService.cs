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



        public GeneralResponseDto<List<StudentListItemResponse>> GetAllStudents(string? search, bool? isActive, int pageNumber, int pageSize)
        {
            GeneralResponseDto<List<StudentListItemResponse>> response = new();

            var studentsResult = context.Students.Where(s => !s.IsDeleted).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                studentsResult = studentsResult.Where(s => s.FullName.Contains(search));
            }

            if (isActive.HasValue)
            {
                studentsResult = studentsResult.Where(s => s.IsActive == isActive.Value);
            }

            var students = studentsResult.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(s => new StudentListItemResponse
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                IsActive = s.IsActive
            }).ToList();

            response.Success = true;
            response.Message = "Students retrieved successfully";
            response.Data = students;

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