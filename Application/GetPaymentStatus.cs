using PaymentsService.Domain;

namespace UsersService.Application;

public class GetPaymentStatus
{
    private readonly IPaymentRepository _repository;

    public GetPaymentStatus(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Payment?> ExecuteAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}

