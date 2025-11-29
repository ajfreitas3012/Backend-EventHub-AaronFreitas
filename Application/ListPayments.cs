using PaymentsService.Domain;

namespace UsersService.Application;

public class ListPayments
{
    private readonly IPaymentRepository _repository;

    public ListPayments(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Payment>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

