using TrainingCenter.Common;
using TrainingCenter.DTOs;

public interface IPaymentService
{
    GeneralResponseDto<List<PaymentResponse>> GetAllPayments(DateTime? fromDate,DateTime? toDate,string? status);

    GeneralResponseDto<PaymentResponse> CreatePayment(CreatePaymentRequest request);

    GeneralResponseDto<List<PaymentResponse>> GetEnrollmentPayments(int enrollmentId);

    GeneralResponseDto<bool> UpdatePaymentStatus(int id, UpdatePaymentStatusRequest request);
}