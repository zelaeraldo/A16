using A16.Models;

public class EventScheduleItem
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public string Title { get; set; }
    public string Speaker { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
