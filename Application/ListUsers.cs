using UsersService.Domain;

namespace UsersService.Application;

public class ListUsers
{
    private readonly IUserRepository _repository;

    public ListUsers(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<User>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
