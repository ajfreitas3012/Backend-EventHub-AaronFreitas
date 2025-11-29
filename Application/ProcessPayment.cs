using PaymentsService.Domain;

namespace UsersService.Application;

public class ProcessPayment
{
    private readonly IPaymentRepository _repository;

    public ProcessPayment(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Payment payment)
    {
        await _repository.AddAsync(payment);
    }
}

