
using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext context;
        private readonly ICurrentUserService currentUserService;

        public InstructorService(AppDbContext context,ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public GeneralResponseDto<InstructorDetailsResponse> CreateInstructor(CreateInstructorRequest instructorRequest)
        {
            GeneralResponseDto<InstructorDetailsResponse> responseDto = new();

            if (context.Instructors.Any(i => i.Email == instructorRequest.Email))
            {
                responseDto.Success = false;
                responseDto.Message = "Email already exists";
                responseDto.ErrorType = ErrorType.Conflict;
                return responseDto;
            }
            Instructor instructor = new()
            {
                FullName = instructorRequest.FullName,
                Email = instructorRequest.Email,
                Specialization = instructorRequest.Specialization,
                Bio = instructorRequest.Bio,
                IsActive = instructorRequest.IsActive,
                CreatedAt = DateTime.UtcNow
            };
            context.Instructors.Add(instructor);
            context.SaveChanges();
            InstructorDetailsResponse detailsResponse = new()
            {
                InstructorId = instructor.InstructorId,
                FullName = instructor.FullName,
                Email = instructor.Email,
                Specialization = instructor.Specialization,
                Bio = instructor.Bio,
                IsActive = instructor.IsActive,
                CreatedAt = instructor.CreatedAt
            };
            responseDto.Success = true;
            responseDto.Message = "Instructor created successfully";
            responseDto.Data = detailsResponse;

            return responseDto;
        }

        public GeneralResponseDto<bool> DeleteInstructor(int id)
        {
            GeneralResponseDto<bool> responseDto = new();
            var instructor = context.Instructors.FirstOrDefault(s => s.InstructorId == id);

            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
            }
            else
            {

                context.Remove(instructor);
                context.SaveChanges();

                responseDto.Success = true;
                responseDto.Message = "Instructor deleted successfully";
            }
            return responseDto;
        }

        public GeneralResponseDto<List<InstructorListItemResponse>> GetAllInstructors()
        {
            GeneralResponseDto<List<InstructorListItemResponse>> response = new();
            var instructors = context.Instructors.Select(i => new InstructorListItemResponse
            {
                InstructorId = i.InstructorId,
                FullName = i.FullName,
                Email = i.Email,
                Specialization = i.Specialization
            }).ToList();

            response.Success = true;
            response.Message = "Instructors retrieved successfully";
            response.Data = instructors;

            return response;
        }

        public GeneralResponseDto<InstructorDetailsResponse> GetInstructorById(int id)
        {
            GeneralResponseDto<InstructorDetailsResponse> responseDto = new();

            var instructor = context.Instructors.FirstOrDefault(i => i.InstructorId == id);

            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }

            //Instructor 
            if(currentUserService.Role == Role.Instructor)
            {
                var currentUser = context.Users.FirstOrDefault(u=> u.Id == currentUserService.UserId);
                if (currentUser?.InstructorId != id)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to view this instructor.";
                    responseDto.ErrorType = ErrorType.Forbidden;
                    return responseDto;
                }

            }

            InstructorDetailsResponse detailsResponse = new()
            {
                InstructorId = instructor.InstructorId,
                FullName = instructor.FullName,
                Email = instructor.Email,
                Specialization = instructor.Specialization,
                Bio = instructor.Bio,
                IsActive = instructor.IsActive,
                CreatedAt = instructor.CreatedAt
            };
            responseDto.Success = true;
            responseDto.Message = "Instructor found successfully";
            responseDto.Data = detailsResponse;

            return responseDto;
        }

        public GeneralResponseDto<List<InstructorTracksResponse>> GetInstructorTracks(int id)
        {
            GeneralResponseDto<List<InstructorTracksResponse>> responseDto = new();

            var instructor = context.Instructors.Include(i => i.TrainingTracks).FirstOrDefault(i => i.InstructorId == id);

            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }

             //Instructor 
            if(currentUserService.Role == Role.Instructor)
            {
                var currentUser = context.Users.FirstOrDefault(u=> u.Id == currentUserService.UserId);
                if (currentUser?.InstructorId != id)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to view this tracks.";
                    responseDto.ErrorType = ErrorType.Forbidden;
                    return responseDto;
                }

            }

            var tracks = instructor.TrainingTracks.Select(t => new InstructorTracksResponse
            {
                TrackId = t.TrackId,
                Title = t.Title,
                Code = t.Code,
                Level = t.Level,
                Status = t.Status
            })
                .ToList();

            responseDto.Success = true;
            responseDto.Message = "Instructor tracks retrieved successfully";
            responseDto.Data = tracks;

            return responseDto;
        }


        public GeneralResponseDto<InstructorDetailsResponse> UpdateInstructor(int id, UpdateInstructorRequest instructorRequest)
        {
            GeneralResponseDto<InstructorDetailsResponse> responseDto = new();
            
            var instructor = context.Instructors.FirstOrDefault(i => i.InstructorId == id);
            if (instructor is null)
            {
                responseDto.Success = false;
                responseDto.Message = "Instructor not found";
                responseDto.ErrorType = ErrorType.NotFound;
                return responseDto;
            }
              //Instructor 
            if(currentUserService.Role == Role.Instructor)
            {
                var currentUser = context.Users.FirstOrDefault(u=> u.Id == currentUserService.UserId);
                if (currentUser?.InstructorId != id)
                {
                    responseDto.Success = false;
                    responseDto.Message = "You are not allowed to update this instructor.";
                    responseDto.ErrorType = ErrorType.Forbidden;
                    return responseDto;
                }

            }

            bool emailExists = context.Instructors.Any(i => i.InstructorId != id && i.Email == instructorRequest.Email);
            if (emailExists)
            {
                responseDto.Success = false;
                responseDto.ErrorType = ErrorType.Conflict;
                responseDto.Message = "Email already exists";
                return responseDto;
            }

            else
            {
                instructor.FullName = instructorRequest.FullName;
                instructor.Email = instructorRequest.Email;
                instructor.IsActive = instructorRequest.IsActive;
                instructor.Specialization = instructorRequest.Specialization;
                instructor.Bio = instructorRequest.Bio;
                context.SaveChanges();

                InstructorDetailsResponse detailsResponse = new()
                {
                    InstructorId = instructor.InstructorId,
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    Specialization = instructor.Specialization,
                    Bio = instructor.Bio,
                    IsActive = instructor.IsActive,
                    CreatedAt = instructor.CreatedAt,

                };

                responseDto.Success = true;
                responseDto.Message = "Instructor updated successfully";
                responseDto.Data = detailsResponse;

            }

            return responseDto;
        }
    }
}