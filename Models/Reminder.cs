using A16.Models;

public class Reminder
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public DateTime ReminderDate { get; set; }
    public string Message { get; set; }
}
