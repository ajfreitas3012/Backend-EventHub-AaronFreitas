namespace UsersService.Domain;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;

    private User() { } // EF Core necesita constructor vacío

    public User(Guid id, string name, Email email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}
