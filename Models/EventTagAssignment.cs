using A16.Models;

public class EventTagAssignment
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public int TagId { get; set; }
    public EventTag Tag { get; set; }
}
