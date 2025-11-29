namespace UsersService.Domain;

public sealed class Email
{
    public string Value { get; private set; } = string.Empty;

    private Email() { } // EF Core necesita constructor vacío

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email no puede estar vacío.");

        if (!value.Contains("@") || !value.Contains("."))
            throw new ArgumentException("Email no tiene formato válido.");

        Value = value;
    }

    public override string ToString() => Value;
}
