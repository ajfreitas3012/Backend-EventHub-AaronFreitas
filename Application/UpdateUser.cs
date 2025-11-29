using UsersService.Domain;

namespace UsersService.Application;

public class UpdateUser
{
    public User Execute(Guid id, string name, string emailString)
    {
        var email = new Email(emailString);
        var user = new User(id, name, email);
        return user;
    }
}
