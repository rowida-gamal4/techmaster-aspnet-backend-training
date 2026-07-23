using Drill09.DTOs;

namespace Drill09.Services
{
    public interface IEnrollmentService
    {
        public PaymentSummaryDto? GetPaymentSummary(int id) ;
    }
}