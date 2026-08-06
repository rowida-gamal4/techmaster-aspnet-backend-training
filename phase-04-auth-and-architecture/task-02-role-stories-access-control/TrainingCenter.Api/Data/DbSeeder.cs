using Microsoft.EntityFrameworkCore;
using TrainingCenter.Entities;

namespace TrainingCenter.Api.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(AppDbContext context)
        {
            const string adminEmail = "admin@gmail.com";

            var admin = await context.Users.FirstOrDefaultAsync(u => u.Email == adminEmail);

            if (admin == null)
            {
                var newAdmin = new ApplicationUser
                {
                    FullName = "Admin",
                    Email = adminEmail,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    Role = Role.Admin,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    StudentId = null,
                    InstructorId = null
                };

                context.Users.Add(newAdmin);
                await context.SaveChangesAsync();
            }
        }
    }
}