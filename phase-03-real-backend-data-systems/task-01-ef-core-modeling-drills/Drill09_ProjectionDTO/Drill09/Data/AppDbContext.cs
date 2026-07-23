using Drill09.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drill09.Api.Data
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

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<PaymentSummary> PaymentSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasOne(s => s.StudentProfile).WithOne(p => p.Student).HasForeignKey<StudentProfile>(p => p.StudentId);

            modelBuilder.Entity<Instructor>().HasMany(i => i.TrainingTracks).WithOne(t => t.Instructor).HasForeignKey(t => t.InstructorId);

            modelBuilder.Entity<Student>().HasMany(s=>s.Enrollments).WithOne(e => e.Student).HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<TrainingTrack>().HasMany(s=>s.Enrollments).WithOne(e => e.TrainingTrack).HasForeignKey(e => e.TrainingTrackId);

            modelBuilder.Entity<PaymentSummary>().HasOne(ps => ps.Enrollment).WithOne(e => e.PaymentSummary).HasForeignKey<PaymentSummary>(ps => ps.EnrollmentId);
       
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = 1,
                   FullName = "Rowida Gamal",
                   Email = "rowida@gmail.com",
                   CreatedAt = new DateTime(2026, 1, 1),
                   IsActive = true
               },
                new Student
               {
                   Id = 2,
                   FullName = "Arwa Ali",
                   Email = "arwaa@gmail.com",
                   CreatedAt = new DateTime(2026, 1, 1),
                   IsActive = true
               },            
                new Student
                {
                    Id = 4,
                    FullName = "Gamal Hassan",
                    Email = "gamal@gmail.com",
                    CreatedAt = new DateTime(2026, 1, 4),
                    IsActive = true
                },
                new Student
                {
                    Id = 3,
                    FullName = "Hassan Mohamed",
                    Email = "hassan@gmail.com",
                    CreatedAt = new DateTime(2026, 1, 3),
                    IsActive = true
                },
                new Student
                {
                    Id = 5,
                    FullName = "Mona Ali",
                    Email = "mona@gmail.com",
                    CreatedAt = new DateTime(2026, 1, 5),
                    IsActive = true
                }
               );

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
                    InstructorId = 1,
                    CreatedAt = new DateTime(2026,1,1),
                },
                new TrainingTrack
                {
                    TrackId = 2,
                    TrackName = "Entity Framework Core",
                    InstructorId = 1,
                    CreatedAt = new DateTime(2026,1,1),
                },
                new TrainingTrack
                {
                    TrackId = 3,
                    TrackName = "Flutter",
                    InstructorId = 2,
                    CreatedAt = new DateTime(2026,1,1),
                }
            );
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    EnrollmentId = 1,
                    StudentId = 2,
                    TrainingTrackId = 1 ,
                    Status = "Active" ,
                    EnrollmentDate = new DateTime(2026, 1, 1) ,
                    FinalGrade = 100,
                    CreatedAt = new DateTime(2026,6,6),
                },
                new Enrollment
                {
                    EnrollmentId = 2,
                    StudentId = 1,
                    TrainingTrackId = 2 ,
                    Status = "Active" ,
                    EnrollmentDate = new DateTime(2026, 2, 2) ,
                    FinalGrade = 90,
                    CreatedAt = new DateTime(2026,6,6),

                },
                new Enrollment
                {
                    EnrollmentId = 3,
                    StudentId = 1,
                    TrainingTrackId = 1 ,
                    Status = "Active" ,
                    EnrollmentDate = new DateTime(2026, 3, 3) ,
                    FinalGrade = 90,
                    CreatedAt = new DateTime(2026,6,6),
                },
                new Enrollment
                {
                    EnrollmentId = 4,
                    StudentId = 3,
                    TrainingTrackId = 3,
                    Status = "Active",
                    EnrollmentDate = new DateTime(2026, 4, 1),
                    FinalGrade = 95,
                    CreatedAt = new DateTime(2026,6,6),
                },
                new Enrollment
                {
                    EnrollmentId = 5,
                    StudentId = 4,
                    TrainingTrackId = 2,
                    Status = "Completed",
                    EnrollmentDate = new DateTime(2026, 5, 1),
                    FinalGrade = 88,
                    CreatedAt = new DateTime(2026,6,6),
                }
            );
            modelBuilder.Entity<PaymentSummary>().HasData(
                new PaymentSummary
                {
                    Id = 1,
                    EnrollmentId = 1,
                    TotalRequired = 5000m,
                    TotalPaid = 3000m,
                    PaymentStatus = PaymentStatus.PartiallyPaid
                },
                    new PaymentSummary
                    {
                        Id = 2,
                        EnrollmentId = 2,
                        TotalRequired = 4000m,
                        TotalPaid = 4000m,
                        PaymentStatus = PaymentStatus.Paid
                    }
             );
        }
    }

}