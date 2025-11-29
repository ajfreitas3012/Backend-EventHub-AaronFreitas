using EventsService.Domain;

namespace UsersService.Application;

public class GetEventById
{
    private readonly IEventRepository _repository;

    public GetEventById(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<Event?> ExecuteAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}

