using Microsoft.EntityFrameworkCore;
using RefactoredCode.Api.Data;
using RefactoredCode.DTOs;
using RefactoredCode.Entities;

namespace RefactoredCode.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext context;

        public EnrollmentService(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<PaymentResponse?> CreatePaymentAsync(CreatePaymentRequest request)
        {
            if (request.Amount <= 0)
                return null;

            var enrollment = await context.Enrollments.Include(e => e.TrainingTrack).Include(e => e.Payments).FirstOrDefaultAsync(e => e.EnrollmentId == request.EnrollmentId);

            if (enrollment == null)
                return null;

            decimal totalPaid = enrollment.Payments.Where(p => p.PaymentStatus == PaymentStatus.Paid).Sum(p => p.Amount);

            decimal remaining = enrollment.TrainingTrack.Price - totalPaid;

            if (request.Amount > remaining)
                return null;

            Payment payment = new()
            {
                EnrollmentId = request.EnrollmentId,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = Enum.Parse<PaymentStatus>(request.PaymentStatus),
                ReferenceNumber = request.ReferenceNumber,
                Note = request.Note
            };

            context.Payments.Add(payment);

            if (payment.PaymentStatus == PaymentStatus.Paid)
            {
                enrollment.Status = EnrollmentStatus.Active;
            }

            await context.SaveChangesAsync();

            return new PaymentResponse
            {
                PaymentId = payment.PaymentId,
                EnrollmentId = payment.EnrollmentId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                Status = payment.PaymentStatus.ToString(),
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var enrollment = await context.Enrollments.FirstOrDefaultAsync(e => e.EnrollmentId == id);

            if (enrollment == null)
                return false;

            enrollment.IsDeleted = true;
            enrollment.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<EnrollmentListItemResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await context.Enrollments.Where(e => !e.IsDeleted).Select(e => new EnrollmentListItemResponse
            {
                EnrollmentId = e.EnrollmentId,
                StudentName = e.Student.FullName,
                TrackTitle = e.TrainingTrack.Title,
                EnrollmentDate = e.EnrollmentDate,
                Status = e.Status
            }).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return data;
        }

        public async Task<EnrollmentResponse?> CreateAsync(CreateEnrollmentRequest request)
        {
            var student = await context.Students.FirstOrDefaultAsync(s => s.StudentId == request.StudentId);

            if (student == null)
                return null;

            var track = await context.TrainingTracks.FirstOrDefaultAsync(t => t.TrackId == request.TrainingTrackId);

            if (track == null)
                return null;

            bool duplicate = await context.Enrollments.AnyAsync(e => e.StudentId == request.StudentId && e.TrainingTrackId == request.TrainingTrackId && e.Status == EnrollmentStatus.Active && !e.IsDeleted);

            if (duplicate)
                return null;

            int activeCount = await context.Enrollments.CountAsync(e => e.TrainingTrackId == request.TrainingTrackId && e.Status == EnrollmentStatus.Active && !e.IsDeleted);

            if (activeCount >= track.Capacity)
                return null;

            Enrollment enrollment = new()
            {
                StudentId = request.StudentId,
                TrainingTrackId = request.TrainingTrackId,
                EnrollmentDate = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Status = EnrollmentStatus.Pending,
                ProgressPercentage = request.ProgressPercentage
            };

            context.Enrollments.Add(enrollment);

            await context.SaveChangesAsync();

            return new EnrollmentResponse
            {
                EnrollmentId = enrollment.EnrollmentId,
                StudentName = enrollment.Student.FullName,
                TrackTitle = enrollment.TrainingTrack.Title,
                EnrollmentDate = enrollment.EnrollmentDate,
                Status = enrollment.Status,
                ProgressPercentage = enrollment.ProgressPercentage,
                FinalResult = enrollment.FinalResult
            };
        }
    }
}