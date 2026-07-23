using Drill06.DTOs;

namespace Drill06.Services
{
    public interface IEnrollmentService
    {
        public PaymentSummaryDto? GetPaymentSummary(int id) ;
    }
}