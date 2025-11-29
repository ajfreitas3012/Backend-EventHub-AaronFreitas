using EventsService.Domain;

namespace UsersService.Application;

public class ListEvent
{
    private readonly IEventRepository _repository;

    public ListEvent(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Event>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}

