using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class OrganizerProfile
{
    [Key]
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    

    public string OrganizationName { get; set; }
    public string ContactEmail { get; set; }
    public string Website { get; set; }
    public string Bio { get; set; }
}
