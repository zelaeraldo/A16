using A16.Models;

public class Comment
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public int EventId { get; set; }
    public string UserId { get; set; }

    public string Content { get; set; }
    public DateTime PostedAt { get; set; }
}
