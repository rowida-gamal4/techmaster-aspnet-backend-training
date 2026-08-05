using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs.Auth;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService tokenService;
        private readonly AppDbContext context;
        private readonly JwtSettings settings;

        public AuthService(ITokenService tokenService, AppDbContext context, IOptions<JwtSettings> options)
        {
            this.tokenService = tokenService;
            this.context = context;
            settings = options.Value;
        }
        public async Task<GeneralResponseDto<RegisterResponse>> RegisterAsync(RegisterRequest request)
        {
            var response = new GeneralResponseDto<RegisterResponse>();

            if (request.Password != request.ConfirmPassword)
            {
                response.ErrorType = ErrorType.Validation;
                response.Message = "Password and Confirm Password do not match.";
                return response;
            }

            if (!IsStrongPassword(request.Password))
            {
                response.ErrorType = ErrorType.Validation;
                response.Message = "Password must be at least 8 characters and contain uppercase, lowercase, number, and special character.";
                return response;
            }



            var exists = await context.Users.AnyAsync(u => u.Email == request.Email);
            if (exists)
            {
                response.ErrorType = ErrorType.BadRequest;
                response.Message = "Email already exists.";
                return response;

            }

            //check role

            if (request.Role == Role.Admin)
            {
                response.ErrorType = ErrorType.Validation;
                response.Message = "Admin registration is not allowed.";
                return response;
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                int? studentId = null;
                int? instructorId = null;
                if (request.Role == Role.Student)
                {
                    var student = new Student
                    {
                        FullName = request.FullName,
                        Email = request.Email,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    };

                    context.Students.Add(student);
                    await context.SaveChangesAsync();

                    studentId = student.StudentId;
                }
                else if (request.Role == Role.Instructor)
                {
                    var instructor = new Instructor
                    {
                        FullName = request.FullName,
                        Email = request.Email,
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    };

                    context.Instructors.Add(instructor);
                    await context.SaveChangesAsync();

                    instructorId = instructor.InstructorId;
                }


                var user = new ApplicationUser
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    Role = request.Role,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    StudentId = studentId,
                    InstructorId = instructorId
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                response.Success = true;
                response.Message = "User registered successfully.";
                response.Data = new RegisterResponse
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role,

                };

                return response;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                response.ErrorType = ErrorType.Conflict;
                response.Message = "Failed to register.";
                return response;
            }


        }
        public async Task<GeneralResponseDto<string>> ChangePasswordAsync(int userId, ChangePasswordRequest request)
        {
            var response = new GeneralResponseDto<string>();

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                response.ErrorType = ErrorType.NotFound;
                response.Message = "User not found.";
                return response;
            }
            if (!user.IsActive)
            {
                response.ErrorType = ErrorType.BadRequest;
                response.Message = "Account is inactive.";
                return response;
            }
            var isCurrentPassValid = BCrypt.Net.BCrypt.Verify(request.CurrentPassword,user.PasswordHash);

            if (!isCurrentPassValid)
            {
                response.ErrorType = ErrorType.BadRequest;
                response.Message = "Current password is invalid.";
                return response;
            }
             if (!IsStrongPassword(request.NewPassword))
            {
                response.ErrorType = ErrorType.Validation;
                response.Message = "Not strong password.";

                return response;
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.UpdatedAt = DateTime.UtcNow;
            response.Success = true;
            response.Message = "Password changed successfully.";
            response.Data = "Password updated successfully.";

            return response;
        }

        public async Task<GeneralResponseDto<CurrentUserResponse>> GetCurrentUser(int userId)
        {
            var response = new GeneralResponseDto<CurrentUserResponse>();

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                response.ErrorType = ErrorType.NotFound;
                response.Message = "User not found.";
                return response;
            }
            if (!user.IsActive)
            {
                response.ErrorType = ErrorType.BadRequest;
                response.Message = "User is inactive.";
                return response;
            }
            response.Success = true;
            response.Message = "Current user retrieved successfully.";
            response.Data = new CurrentUserResponse
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                LinkedStudentId = user.StudentId,
                LinkedInstructorId = user.InstructorId
            };

            return response;

        }

        public async Task<GeneralResponseDto<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var response = new GeneralResponseDto<AuthResponse>();

            var email = request.Email.Trim().ToLower();

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email);
            if (user == null)
            {
                response.ErrorType = ErrorType.BadRequest;
                response.Message = "Invalid email or password.";
                return response;
            }

            if (!user.IsActive)
            {
                response.ErrorType = ErrorType.BadRequest;
                response.Message = "Account is inactive.";
                return response;
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                response.ErrorType = ErrorType.BadRequest;
                response.Message = "Invalid email or password.";
                return response;
            }
            var accessToken = tokenService.GenerateToken(user.Id, user.Email, user.FullName, user.Role.ToString());

            user.LastLoginAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            response.Success = true;
            response.Message = "Login successful.";
            response.Data = new AuthResponse
            {
                AccessToken = accessToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(settings.ExpirationMinutes),
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };

            return response;
        }

        public Task LogoutAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponseDto<AuthResponse>> RefreshTokenAsync(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
        }

        private static bool IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8)
                return false;

            return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && password.Any(ch => !char.IsLetterOrDigit(ch));
        }


    }
}