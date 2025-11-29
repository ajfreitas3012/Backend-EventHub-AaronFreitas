using EventsService.Domain;

namespace UsersService.Application;

public class CreateEvent
{
    private readonly IEventRepository _repository;

    public CreateEvent(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Event ev)
    {
        await _repository.AddAsync(ev);
    }
}
