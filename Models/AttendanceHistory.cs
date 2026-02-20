using A16.Models;

public class AttendanceHistory
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public int EventId { get; set; }
    public string UserId { get; set; }
    public DateTime CheckedInAt { get; set; }
}
