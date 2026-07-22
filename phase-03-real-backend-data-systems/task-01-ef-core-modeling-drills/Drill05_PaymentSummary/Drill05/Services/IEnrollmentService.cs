using Drill05.DTOs;

namespace Drill05.Services
{
    public interface IEnrollmentService
    {
        public PaymentSummaryDto? GetPaymentSummary(int id) ;
    }
}