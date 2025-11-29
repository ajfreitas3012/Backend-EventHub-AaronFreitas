using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PaymentsService.Domain;

namespace PaymentsService.Infrastructure;

public class EfPaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public EfPaymentRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
        => await _context.Payments.FindAsync(id);

    public async Task<IEnumerable<Payment>> GetAllAsync()
        => await _context.Payments.ToListAsync();

    public async Task UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment is not null)
        {
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }
    }
}

