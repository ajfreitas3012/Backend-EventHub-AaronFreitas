namespace PaymentsService.Domain;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment);
    Task<Payment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Payment>> GetAllAsync();
    Task UpdateAsync(Payment payment);
    Task DeleteAsync(Guid id);
}
