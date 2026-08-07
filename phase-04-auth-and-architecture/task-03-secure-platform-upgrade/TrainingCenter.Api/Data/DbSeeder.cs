using Microsoft.EntityFrameworkCore;
using TrainingCenter.Entities;

namespace TrainingCenter.Api.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(AppDbContext context)
        {
            //Admin 
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
            //Students 
            var students = await context.Students.Where(s => !context.Users.Any(u => u.StudentId == s.StudentId)).ToListAsync();

            foreach (var student in students)
            {
                var user = new ApplicationUser
                {
                    FullName = student.FullName,
                    Email = student.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Student@123"),
                    Role = Role.Student,
                    IsActive = student.IsActive,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    StudentId = student.StudentId,
                    InstructorId = null
                };

                context.Users.Add(user);
            }
            //Instructors
            var instructors = await context.Instructors.Where(i => !context.Users.Any(u => u.InstructorId == i.InstructorId)).ToListAsync();

            foreach (var instructor in instructors)
            {
                var user = new ApplicationUser
                {
                    FullName = instructor.FullName,
                    Email = instructor.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Instructor@123"),
                    Role = Role.Instructor,
                    IsActive = instructor.IsActive,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    StudentId = null,
                    InstructorId = instructor.InstructorId
                };

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();


        }
    }
}