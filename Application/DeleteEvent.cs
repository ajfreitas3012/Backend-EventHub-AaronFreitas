using EventsService.Domain;

namespace UsersService.Application;

public class DeleteEvent
{
    private readonly IEventRepository _repository;

    public DeleteEvent(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is not null)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

