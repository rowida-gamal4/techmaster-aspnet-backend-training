using Drill02.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill02.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students {get;set;}
        public DbSet<StudentProfile> StudentProfiles {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(s=>s.StudentProfile).WithOne(p=>p.Student).HasForeignKey<StudentProfile>(p=>p.StudentId);

             modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Rowida Gamal",
                    Email = "rowida@gmail.com",
                    CreatedAt = new DateTime(2026, 1, 1),
                    IsActive = true
                });
            
             modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile
                {
                    NationalId = 123456789,
                    Address = "Cairo",
                    EmergencyPhone = "01122055628",
                    DateOfBirth = new DateTime(2005, 5, 4),
                    StudentId = 1
                });
    }
    }

}