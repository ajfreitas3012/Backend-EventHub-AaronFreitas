namespace EventsService.Domain;

public interface IEventRepository
{
    Task AddAsync(Event ev);
    Task<Event?> GetByIdAsync(Guid id);
    Task<IEnumerable<Event>> GetAllAsync();
    Task UpdateAsync(Event ev);
    Task DeleteAsync(Guid id);
}
