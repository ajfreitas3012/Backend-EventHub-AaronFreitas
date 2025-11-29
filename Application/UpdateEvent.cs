using EventsService.Domain;

namespace UsersService.Application;

public class UpdateEvent
{
    private readonly IEventRepository _repository;

    public UpdateEvent(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Event ev)
    {
        var existing = await _repository.GetByIdAsync(ev.Id);
        if (existing is not null)
        {
            await _repository.UpdateAsync(ev);
        }
    }
}

