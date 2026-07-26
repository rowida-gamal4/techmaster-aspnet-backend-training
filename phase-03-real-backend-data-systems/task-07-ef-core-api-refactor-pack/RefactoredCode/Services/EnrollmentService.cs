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


        public async Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request)
        {
            var enrollment = await context.Enrollments .FirstOrDefaultAsync(e => e.EnrollmentId == request.EnrollmentId);

            if (enrollment == null)
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
            var enrollment = await context.Enrollments.FindAsync(id);

            if (enrollment == null)
                return false;

            context.Enrollments.Remove(enrollment);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<EnrollmentListItemResponse>> GetAllAsync(int pageNumber, int pageSize)
        {
            var data = await context.Enrollments.Select(e => new EnrollmentListItemResponse
            {
                EnrollmentId = e.EnrollmentId,
                StudentName = e.Student.FullName,
                TrackTitle = e.TrainingTrack.Title,
                EnrollmentDate = e.EnrollmentDate,
                Status = e.Status
            }).ToListAsync();
            return data;
        }

        public async Task<EnrollmentResponse> CreateAsync(CreateEnrollmentRequest request)
        {
            var enrollment = new Enrollment
            {
                StudentId = request.StudentId,
                TrainingTrackId = request.TrainingTrackId,
                EnrollmentDate = DateTime.UtcNow,
                Status = EnrollmentStatus.Active,
                ProgressPercentage = 0,
                CreatedAt = DateTime.UtcNow
            };
            context.Enrollments.Add(enrollment);
            await context.SaveChangesAsync();

            EnrollmentResponse response = new()
            {
                EnrollmentId = enrollment.EnrollmentId,
                StudentName = enrollment.Student.FullName,
                TrackTitle = enrollment.TrainingTrack.Title,
                EnrollmentDate = enrollment.EnrollmentDate,
                Status = enrollment.Status,
                ProgressPercentage = enrollment.ProgressPercentage,
                FinalResult = enrollment.FinalResult,
                PaymentStatus = "Pending"
            };
            return response;
        }
    }
}