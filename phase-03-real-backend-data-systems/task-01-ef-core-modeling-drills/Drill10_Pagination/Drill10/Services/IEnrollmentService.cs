using Drill10.DTOs;

namespace Drill10.Services
{
    public interface IEnrollmentService
    {
        public PaymentSummaryDto? GetPaymentSummary(int id) ;
    }
}