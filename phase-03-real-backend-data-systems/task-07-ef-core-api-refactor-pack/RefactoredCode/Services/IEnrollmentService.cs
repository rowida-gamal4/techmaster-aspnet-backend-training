using RefactoredCode.DTOs;

namespace RefactoredCode.Services
{
    public interface IEnrollmentService
    {
        Task<List<EnrollmentListItemResponse>> GetAllAsync(int pageNumber, int pageSize);

        Task<EnrollmentResponse> CreateAsync(CreateEnrollmentRequest request);

        Task<PaymentResponse> CreatePaymentAsync(CreatePaymentRequest request);

        Task<bool> DeleteAsync(int id);
    }
}