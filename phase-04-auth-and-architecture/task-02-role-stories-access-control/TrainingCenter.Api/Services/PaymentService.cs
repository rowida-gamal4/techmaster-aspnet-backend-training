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
        private readonly ICurrentUserService currentUserService;

        public PaymentService(AppDbContext context, ICurrentUserService currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        //admin only , student own payments
        public GeneralResponseDto<List<PaymentResponse>> GetAllPayments(DateTime? fromDate, DateTime? toDate, string? status)
        {
            GeneralResponseDto<List<PaymentResponse>> response = new();

            if (fromDate.HasValue && toDate.HasValue && fromDate > toDate)
            {
                response.Success = false;
                response.Message = "From date cannot be > To date.";
                response.ErrorType = ErrorType.BadRequest;
                return response;
            }
            var paymentResult = context.Payments.AsQueryable();

            //student 
            if (currentUserService.Role == Role.Student)
            {
                var currentUser = context.Users.FirstOrDefault(u => u.Id == currentUserService.UserId);

                if (currentUser?.StudentId == null)
                {
                    response.Success = false;
                    response.Message = "Student profile not found.";
                    response.ErrorType = ErrorType.NotFound;
                    return response;
                }

                paymentResult = paymentResult.Where(p => p.Enrollment.StudentId == currentUser.StudentId.Value);
            }

            if (fromDate.HasValue)
                paymentResult = paymentResult.Where(p => p.PaymentDate >= fromDate.Value);
            if (toDate.HasValue)
                paymentResult = paymentResult.Where(p => p.PaymentDate <= toDate.Value);
            if (!string.IsNullOrWhiteSpace(status))
            {
                if (!Enum.TryParse<PaymentStatus>(status, true, out var paymentStatus))
                {
                    response.Success = false;
                    response.Message = "Invalid payment status.";
                    response.ErrorType = ErrorType.BadRequest;
                    return response;
                }
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

        //admin only
        public GeneralResponseDto<PaymentResponse> CreatePayment(CreatePaymentRequest request)
        {
            GeneralResponseDto<PaymentResponse> response = new();

            if (request.Amount <= 0)
            {
                response.Success = false;
                response.Message = "Payment amount must be > zero.";
                response.ErrorType = ErrorType.BadRequest;
                return response;
            }



            var enrollment = context.Enrollments
                .FirstOrDefault(e => e.EnrollmentId == request.EnrollmentId);

            if (enrollment is null)
            {
                response.Success = false;
                response.Message = "Enrollment not found";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            var track = context.TrainingTracks.First(t => t.TrackId == enrollment.TrainingTrackId);

            decimal totalPaid = context.Payments.Where(p => p.EnrollmentId == enrollment.EnrollmentId && p.PaymentStatus == PaymentStatus.Paid).Sum(p => p.Amount);

            decimal remaining = track.Price - totalPaid;

            if (request.Amount > remaining)
            {
                response.Success = false;
                response.Message = $"Payment exceeds remaining balance ({remaining}).";
                response.ErrorType = ErrorType.BadRequest;
                return response;
            }

            if (!Enum.TryParse<PaymentStatus>(request.PaymentStatus, true, out var paymentStatus))
            {
                response.Success = false;
                response.Message = "Invalid payment status.";
                response.ErrorType = ErrorType.BadRequest;
                return response;
            }

            Payment payment = new()
            {
                EnrollmentId = request.EnrollmentId,
                Amount = request.Amount,
                PaymentMethod = request.PaymentMethod,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = paymentStatus,
                ReferenceNumber = request.ReferenceNumber,
                Note = request.Note
            };

            context.Payments.Add(payment);
            context.SaveChanges();

            if (payment.PaymentStatus == PaymentStatus.Paid)
            {
                enrollment.Status = EnrollmentStatus.Active;
                context.SaveChanges();
            }

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


        //admin , student
        public GeneralResponseDto<List<PaymentResponse>> GetEnrollmentPayments(int enrollmentId)
        {
            GeneralResponseDto<List<PaymentResponse>> response = new();

            var enrollment = context.Enrollments.Include(e => e.Payments).FirstOrDefault(e => e.EnrollmentId == enrollmentId);

            if (enrollment is null)
            {
                response.Success = false;
                response.Message = "Enrollment not found";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            if (currentUserService.Role == Role.Student)
            {
                var currentUser = context.Users.FirstOrDefault(u => u.Id == currentUserService.UserId);

                if (currentUser?.StudentId != enrollment.StudentId)
                {
                    response.Success = false;
                    response.Message = "You are not allowed to view other student's payments.";
                    response.ErrorType = ErrorType.Forbidden;
                    return response;
                }
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


        //admin only
        public GeneralResponseDto<bool> UpdatePaymentStatus(int id, UpdatePaymentStatusRequest request)
        {
            GeneralResponseDto<bool> response = new();

            var payment = context.Payments.FirstOrDefault(p => p.PaymentId == id);

            if (payment is null)
            {
                response.Success = false;
                response.Message = "Payment not found";
                response.ErrorType = ErrorType.NotFound;
                return response;
            }

            if (!Enum.TryParse<PaymentStatus>(request.PaymentStatus, true, out var newStatus))
            {
                response.Success = false;
                response.Message = "Invalid payment status.";
                response.ErrorType = ErrorType.BadRequest;
                return response;
            }

            bool validTransition = (payment.PaymentStatus == PaymentStatus.Pending && (newStatus == PaymentStatus.Paid ||
                  newStatus == PaymentStatus.Failed)) || (payment.PaymentStatus == PaymentStatus.PartiallyPaid && (newStatus == PaymentStatus.Paid || newStatus == PaymentStatus.Failed)) || (payment.PaymentStatus == PaymentStatus.Paid && newStatus == PaymentStatus.Refunded);

            if (!validTransition)
            {
                response.Success = false;
                response.Message = $"Cannot change payment status from {payment.PaymentStatus} to {newStatus}.";
                response.ErrorType = ErrorType.BadRequest;
                return response;
            }

            payment.PaymentStatus = newStatus;

            if (newStatus == PaymentStatus.Paid)
            {
                var enrollment = context.Enrollments.First(e => e.EnrollmentId == payment.EnrollmentId);

                enrollment.Status = EnrollmentStatus.Active;
            }

            context.SaveChanges();

            response.Success = true;
            response.Message = "Payment status updated successfully";
            response.Data = true;

            return response;
        }
    }
}