using A16.Models;

public class EventImage
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public int EventId { get; set; }
    public string ImageUrl { get; set; }
    public DateTime UploadedAt { get; set; }
}
