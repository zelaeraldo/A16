using A16.Models;
using Microsoft.AspNetCore.Identity;

public class EventRegistration
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public DateTime RegistrationDate { get; set; }
    public bool IsConfirmed { get; set; }
}
