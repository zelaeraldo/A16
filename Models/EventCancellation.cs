using A16.Models;

public class EventCancellation
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public int EventId { get; set; }
    public string Reason { get; set; }
    public DateTime CancelledAt { get; set; }
}
