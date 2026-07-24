using Microsoft.EntityFrameworkCore;
using TrainingCenter.Api.Data;
using TrainingCenter.Common;
using TrainingCenter.DTOs;
using TrainingCenter.Entities;
using TrainingCenter.Services.IServices;

namespace TrainingCenter.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext context;

        public PaymentService(AppDbContext context)
        {
            this.context = context;
        }

        public GeneralResponseDto<List<PaymentResponse>> GetAllPayments(DateTime? fromDate, DateTime? toDate, string? status)
        {
            GeneralResponseDto<List<PaymentResponse>> response = new();

            var paymentResult = context.Payments.AsQueryable();

            if (fromDate.HasValue)
                paymentResult = paymentResult.Where(p => p.PaymentDate >= fromDate.Value);
            if (toDate.HasValue)
                paymentResult = paymentResult.Where(p => p.PaymentDate <= toDate.Value);
            if (!string.IsNullOrWhiteSpace(status))
                if (Enum.TryParse<PaymentStatus>(status, true, out var paymentStatus))
                {
                    paymentResult = paymentResult.Where(p => p.PaymentStatus == paymentStatus);
                }

            response.Success = true;
            response.Message = "Payments retrieved successfully";
            response.Data = paymentResult.Select(p => new PaymentResponse
            {
                PaymentId = p.PaymentId,
                EnrollmentId = p.EnrollmentId,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentDate = p.PaymentDate,
                PaymentStatus = p.PaymentStatus.ToString(),
                ReferenceNumber = p.ReferenceNumber
            }).ToList();

            return response;
        }

        public GeneralResponseDto<PaymentResponse> CreatePayment(CreatePaymentRequest request)
        {
            GeneralResponseDto<PaymentResponse> response = new();

            var enrollment = context.Enrollments
                .FirstOrDefault(e => e.EnrollmentId == request.EnrollmentId);

            if (enrollment is null)
            {
                response.Success = false;
                response.Message = "Enrollment not found";
                return response;
            }

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
            context.SaveChanges();

            response.Success = true;
            response.Message = "Payment created successfully";
            response.Data = new PaymentResponse
            {
                PaymentId = payment.PaymentId,
                EnrollmentId = payment.EnrollmentId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus.ToString(),
                ReferenceNumber = payment.ReferenceNumber
            };

            return response;
        }

        public GeneralResponseDto<List<PaymentResponse>> GetEnrollmentPayments(int enrollmentId)
        {
            GeneralResponseDto<List<PaymentResponse>> response = new();

            var enrollment = context.Enrollments.Include(e => e.Payments).FirstOrDefault(e => e.EnrollmentId == enrollmentId);

            if (enrollment is null)
            {
                response.Success = false;
                response.Message = "Enrollment not found";
                return response;
            }

            response.Success = true;
            response.Message = "Payment history retrieved successfully";
            response.Data = enrollment.Payments.Select(p => new PaymentResponse
            {
                PaymentId = p.PaymentId,
                EnrollmentId = p.EnrollmentId,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentDate = p.PaymentDate,
                PaymentStatus = p.PaymentStatus.ToString(),
                ReferenceNumber = p.ReferenceNumber
            }).ToList();

            return response;
        }

        public GeneralResponseDto<bool> UpdatePaymentStatus(int id, UpdatePaymentStatusRequest request)
        {
            GeneralResponseDto<bool> response = new();

            var payment = context.Payments.FirstOrDefault(p => p.PaymentId == id);

            if (payment is null)
            {
                response.Success = false;
                response.Message = "Payment not found";
                return response;
            }

            payment.PaymentStatus = Enum.Parse<PaymentStatus>(request.PaymentStatus);

            context.SaveChanges();

            response.Success = true;
            response.Message = "Payment status updated successfully";
            response.Data = true;

            return response;
        }
    }
}