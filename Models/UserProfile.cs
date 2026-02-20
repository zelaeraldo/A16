using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class UserProfile
{
    [Key]
    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Bio { get; set; }
}
