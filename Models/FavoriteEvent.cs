using A16.Models;

public class FavoriteEvent
{
    public int Id { get; set; }
    public Event Event { get; set; }
    public string UserId { get; set; }
    public int EventId { get; set; }

    public DateTime FavoritedAt { get; set; }
}
