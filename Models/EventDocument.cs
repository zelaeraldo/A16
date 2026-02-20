using A16.Models;

public class EventDocument
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public int EventId { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public DateTime UploadedAt { get; set; }
}
