namespace PaymentsService.Domain;

public class Payment
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid EventId { get; private set; }
    public decimal Amount { get; private set; }
    public string Status { get; private set; } // Ej: "Pending", "Completed", "Failed"

    public Payment(Guid id, Guid userId, Guid eventId, decimal amount, string status)
    {
        Id = id;
        UserId = userId;
        EventId = eventId;
        Amount = amount;
        Status = status;
    }

    public void MarkAsCompleted()
    {
        Status = "Completed";
    }

    public void MarkAsFailed()
    {
        Status = "Failed";
    }
}
