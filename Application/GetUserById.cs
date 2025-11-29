using UsersService.Domain;

namespace UsersService.Application;

public class GetUserById
{
    private readonly IUserRepository _repository;

    public GetUserById(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User?> ExecuteAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}

