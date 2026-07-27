using Microsoft.EntityFrameworkCore;
using TrainingCenter.Entities;

namespace TrainingCenter.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TrainingTrack> TrainingTracks { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.TrainingTracks)
                .WithOne(t => t.Instructor)
                .HasForeignKey(t => t.InstructorId);

            modelBuilder.Entity<TrainingTrack>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.TrainingTrack)
                .HasForeignKey(e => e.TrainingTrackId);

            modelBuilder.Entity<Enrollment>()
                .HasMany(e => e.Payments)
                .WithOne(p => p.Enrollment)
                .HasForeignKey(p => p.EnrollmentId);

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Instructor>()
                .HasIndex(i => i.Email)
                .IsUnique();



            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FullName = "Rowida Gamal",
                    Email = "rowida@gmail.com",
                    CreatedAt = new  DateTime(2026, 5, 1),
                    IsActive = true,
                    IsDeleted = false
                },
                new Student
                {
                    StudentId = 2,
                    FullName = "Arwa Ali",
                    Email = "arwaa@gmail.com",
                    CreatedAt = new  DateTime(2026, 5, 1),
                    IsActive = true,
                    IsDeleted = false
                },
                new Student
                {
                    StudentId = 3,
                    FullName = "Hassan Mohamed",
                    Email = "hassan@gmail.com",
                    CreatedAt = new  DateTime(2026, 5, 1),
                    IsActive = true,
                    IsDeleted = false
                },
                new Student
                {
                    StudentId = 4,
                    FullName = "Gamal Hassan",
                    Email = "gamal@gmail.com",
                    CreatedAt =new  DateTime(2026, 5, 1),
                    IsActive = true,
                    IsDeleted = false
                },
                new Student
                {
                    StudentId = 5,
                    FullName = "Mona Ali",
                    Email = "mona@gmail.com",
                    CreatedAt = new  DateTime(2026, 5, 1),
                    IsActive = true,
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    InstructorId = 1,
                    FullName = "Sama Samy",
                    Email = "sama@gmail.com",
                    Specialization = "Backend Development",
                    IsActive = true,
                    CreatedAt = new  DateTime(2026, 5, 1)
                },
                new Instructor
                {
                    InstructorId = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@gmail.com",
                    Specialization = "Mobile Development",
                    IsActive = true,
                    CreatedAt = new  DateTime(2026, 5, 1)
                }
            );

            modelBuilder.Entity<TrainingTrack>().HasData(
                new TrainingTrack
                {
                    TrackId = 1,
                    Title = "ASP.NET Core",
                    Code = "NET-101",
                    Description = "ASP.NET Core Web API course",
                    Level = 1,
                    StartDate = new  DateTime(2026, 5, 1),
                    EndDate = new DateTime(2026, 12, 12),
                    Status = "Active",
                    InstructorId = 1,
                    CreatedAt = new  DateTime(2026, 5, 1),
                    IsDeleted = false,
                    Capacity = 10
                },
                new TrainingTrack
                {
                    TrackId = 2,
                    Title = "Entity Framework Core",
                    Code = "EF-201",
                    Description = "Object-Relational Mapping with EF Core",
                    Level = 2,
                    StartDate = new  DateTime(2026, 5, 1),
                    EndDate = new DateTime(2026, 12, 12),
                    Status = "Active",
                    InstructorId = 1,
                    CreatedAt = new  DateTime(2026, 5, 1),
                    IsDeleted = false,
                    Capacity = 10
                },
                new TrainingTrack
                {
                    TrackId = 3,
                    Title = "Flutter",
                    Code = "FLT-101",
                    Description = "Mobile app development",
                    Level = 1,
                    StartDate = new  DateTime(2026, 5, 1),
                    EndDate = new DateTime(2026, 12, 12),
                    Status = "Active",
                    InstructorId = 2,
                    CreatedAt = new  DateTime(2026, 5, 1),
                    IsDeleted = false,
                    Capacity = 10
                }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    EnrollmentId = 1,
                    StudentId = 2,
                    TrainingTrackId = 1,
                    Status = "Active",
                    ProgressPercentage = 50,
                    EnrollmentDate = new  DateTime(2026, 5, 1),
                    FinalResult = 100,
                    CreatedAt = new DateTime(2026, 5, 1)
                },
                new Enrollment
                {
                    EnrollmentId = 2,
                    StudentId = 1,
                    TrainingTrackId = 2,
                    Status = "Active",
                    ProgressPercentage = 30,
                    EnrollmentDate = new DateTime(2026, 5, 1),
                    FinalResult = 90,
                    CreatedAt = new DateTime(2026, 5, 1)
                },
                new Enrollment
                {
                    EnrollmentId = 3,
                    StudentId = 1,
                    TrainingTrackId = 1,
                    Status = "Active",
                    ProgressPercentage = 75,
                    EnrollmentDate = new DateTime(2026, 5, 1),
                    FinalResult = 90,
                    CreatedAt = new  DateTime(2026, 5, 1)
                },
                new Enrollment
                {
                    EnrollmentId = 4,
                    StudentId = 3,
                    TrainingTrackId = 3,
                    Status = "Active",
                    ProgressPercentage = 60,
                    EnrollmentDate = new DateTime(2026, 5, 1),
                    FinalResult = 95,
                    CreatedAt = new DateTime(2026, 5, 1)
                },
                new Enrollment
                {
                    EnrollmentId = 5,
                    StudentId = 4,
                    TrainingTrackId = 2,
                    Status = "Completed",
                    ProgressPercentage = 100,
                    EnrollmentDate = new DateTime(2026, 5, 1),
                    FinalResult = 88,
                    CreatedAt = new DateTime(2026, 5, 1)
                }
            );
        }

    }

}