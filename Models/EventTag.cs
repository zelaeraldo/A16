public class EventTag
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<EventTagAssignment> TagAssignments { get; set; }
}
