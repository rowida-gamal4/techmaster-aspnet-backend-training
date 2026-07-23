using Drill08.DTOs;

namespace Drill08.Services
{
    public interface IEnrollmentService
    {
        public PaymentSummaryDto? GetPaymentSummary(int id) ;
    }
}