using A16.Models;

public class EventSponsor
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public string SponsorName { get; set; }
    public string LogoUrl { get; set; }
    public string WebsiteUrl { get; set; }
}
