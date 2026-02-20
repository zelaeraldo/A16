using A16.Models;

public class EventCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Event> Events { get; set; }
}
