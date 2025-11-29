using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using EventsService.Domain;

namespace EventsService.Infrastructure;

public class EfEventRepository : IEventRepository
{
    private readonly AppDbContext _context;

    public EfEventRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(Event ev)
    {
        _context.Events.Add(ev);
        await _context.SaveChangesAsync();
    }

    public async Task<Event?> GetByIdAsync(Guid id)
        => await _context.Events.FindAsync(id);

    public async Task<IEnumerable<Event>> GetAllAsync()
        => await _context.Events.ToListAsync();

    public async Task UpdateAsync(Event ev)
    {
        _context.Events.Update(ev);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var ev = await _context.Events.FindAsync(id);
        if (ev is not null)
        {
            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
        }
    }
}

