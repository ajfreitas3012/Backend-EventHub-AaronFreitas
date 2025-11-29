namespace EventsService.Domain;

public class Event
{
    public Guid Id { get; set; }   // <-- ahora con set público
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int Capacity { get; set; }

    // Constructor vacío requerido por EF y model binding
    public Event() { }

    public Event(Guid id, string title, string category, DateTime date, int capacity)
    {
        Id = id;
        Title = title;
        Category = category;
        Date = date;
        Capacity = capacity;
    }
}

