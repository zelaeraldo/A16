using A16.Models;
using Microsoft.AspNetCore.Identity;

public class EventFeedback
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public string FeedbackText { get; set; }
    public int Rating { get; set; } // 1-5
    public DateTime SubmittedAt { get; set; }
}
