using Drill03.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill03.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TrainingTrack> TrainingTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(s => s.StudentProfile).WithOne(p => p.Student).HasForeignKey<StudentProfile>(p => p.StudentId);

            modelBuilder.Entity<Instructor>().HasMany(i => i.TrainingTracks).WithOne(t => t.Instructor).HasForeignKey(t => t.InstructorId);

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
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    Id = 1,
                    FullName = "Sama Samy",
                    Email = "sama@gmail.com",
                    CreatedAt = new DateTime(2026, 1, 1)
                },
                new Instructor
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@gmail.com",
                    CreatedAt = new DateTime(2026, 1, 2)
                }
            );

            modelBuilder.Entity<TrainingTrack>().HasData(
                new TrainingTrack
                {
                    TrackId = 1,
                    TrackName = "ASP.NET Core",
                    InstructorId = 1
                },
                new TrainingTrack
                {
                    TrackId = 2,
                    TrackName = "Entity Framework Core",
                    InstructorId = 1
                },
                new TrainingTrack
                {
                    TrackId = 3,
                    TrackName = "Flutter",
                    InstructorId = 2
                }
            );
        }
    }

}