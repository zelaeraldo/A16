using Microsoft.AspNetCore.Identity;

public class Notification
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public string Message { get; set; }
    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; }
}
