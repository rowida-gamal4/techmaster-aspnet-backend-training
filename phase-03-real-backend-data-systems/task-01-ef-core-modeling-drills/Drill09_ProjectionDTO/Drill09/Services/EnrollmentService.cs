using Drill09.Api.Data;
using Drill09.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Drill09.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext context;

        public EnrollmentService(AppDbContext context)
        {
            this.context = context;
        }
        public PaymentSummaryDto? GetPaymentSummary(int id)
        {
            var enrollment = context.Enrollments.Include(e=>e.PaymentSummary).FirstOrDefault(e => e.EnrollmentId == id);

            if (enrollment is null)
                return null;

            var dto = new PaymentSummaryDto
            {
                EnrollmentId = enrollment.EnrollmentId,
                TotalRequired = enrollment.PaymentSummary.TotalRequired,
                TotalPaid = enrollment.PaymentSummary.TotalPaid,
                RemainingAmount = enrollment.PaymentSummary.RemainingAmount,
                PaymentStatus = enrollment.PaymentSummary.PaymentStatus
            };

            return dto;
        }
    }
}