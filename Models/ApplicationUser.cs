
using Microsoft.AspNetCore.Identity;

namespace A16.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Shtoni vetitë shtesë të përdoruesit këtu nëse është e nevojshme
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}