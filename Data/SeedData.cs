using A16.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using A16.Models; 

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Ensure database is created and migrated
        await context.Database.MigrateAsync();

        // Seed Roles
        await SeedRoles(roleManager);

        // Seed Users
        await SeedUsers(userManager);

        // Seed Locations
        await SeedLocations(context);

        // Seed Event Categories
        await SeedEventCategories(context);

        // Seed Events
        await SeedEvents(context);

        // Seed other entities...
        await SeedEventTags(context);
        await SeedFAQs(context);
        await SeedOrganizerProfiles(context, userManager);
    }

    private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin", "Organizer", "User" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }

    private static async Task SeedUsers(UserManager<ApplicationUser> userManager)
    {
        // Admin User
        var adminUser = new ApplicationUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            EmailConfirmed = true,
            PhoneNumber = "+355691234567",
            PhoneNumberConfirmed = true
        };

        var adminExists = await userManager.FindByEmailAsync(adminUser.Email);
        if (adminExists == null)
        {
            await userManager.CreateAsync(adminUser, "Admin@123");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // Organizer User
        var organizerUser = new ApplicationUser
        {
            UserName = "organizer@example.com",
            Email = "organizer@example.com",
            EmailConfirmed = true,
            PhoneNumber = "+355692345678",
            PhoneNumberConfirmed = true
        };

        var organizerExists = await userManager.FindByEmailAsync(organizerUser.Email);
        if (organizerExists == null)
        {
            await userManager.CreateAsync(organizerUser, "Organizer@123");
            await userManager.AddToRoleAsync(organizerUser, "Organizer");
        }

        // Regular User
        var regularUser = new ApplicationUser
        {
            UserName = "user@example.com",
            Email = "user@example.com",
            EmailConfirmed = true,
            PhoneNumber = "+355693456789",
            PhoneNumberConfirmed = true
        };

        var userExists = await userManager.FindByEmailAsync(regularUser.Email);
        if (userExists == null)
        {
            await userManager.CreateAsync(regularUser, "User@123");
            await userManager.AddToRoleAsync(regularUser, "User");
        }
    }

    private static async Task SeedLocations(ApplicationDbContext context)
    {
        if (!context.Locations.Any())
        {
            var locations = new[]
            {
                new Location
                {
                    City = "Tirana",
                    Address = "Bulevardi Dëshmorët e Kombit",
                    Country = "Albania"
                    
                },
                new Location
                {
                    City = "Durrës",
                    Address = "Sheshi Liria",
                    
                    Country = "Albania"
                },
                new Location
                {
                    City = "Vlorë",
                    Address = "Sheshi Flamurit",
                    
                    Country = "Albania",
                }
            };

            await context.Locations.AddRangeAsync(locations);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedEventCategories(ApplicationDbContext context)
    {
        if (!context.EventCategories.Any())
        {
            var categories = new[]
            {
                new EventCategory { Name = "Konferenca", Description = "Evente profesionale dhe edukative" },
                new EventCategory { Name = "Koncert", Description = "Performanca muzikore live" },
                new EventCategory { Name = "Sport", Description = "Evente sportive dhe garash" },
                new EventCategory { Name = "Kulturë", Description = "Evente kulturore dhe artistike" },
                new EventCategory { Name = "Festival", Description = "Festivale të ndryshme" }
            };

            await context.EventCategories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedEvents(ApplicationDbContext context)
    {
        if (!context.Events.Any())
        {
            var locations = await context.Locations.ToListAsync();
            var categories = await context.EventCategories.ToListAsync();
            var users = await context.Users.ToListAsync();

            var events = new[]
            {
                new Event
                {
                    Name = "Konferenca e Teknologjisë",
                    Description = "Konferencë mbi teknologjitë e fundit",
                    StartDate = DateTime.Now.AddDays(10),
                    EndDate = DateTime.Now.AddDays(11),
                    Location = locations[0],
                    Category = categories[0],
                   
                    Capacity = 200,
                    
                    IsActive = true,
                   
                },
                new Event
                {
                    Name = "Koncert i Muzikës Popullore",
                    Description = "Koncert me artistë të njohur të muzikës popullore",
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(15),
                    Location = locations[1],
                    Category = categories[1],
                    
                    Capacity = 5000,
                    
                    IsActive = true,
                  
                }
            };

            await context.Events.AddRangeAsync(events);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedEventTags(ApplicationDbContext context)
    {
        if (!context.EventTags.Any())
        {
            var tags = new[]
            {
                new EventTag { Name = "Teknologji" },
                new EventTag { Name = "Muzikë" },
                new EventTag { Name = "Sport" },
                new EventTag { Name = "Art" },
                new EventTag { Name = "Edukim" }
            };

            await context.EventTags.AddRangeAsync(tags);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedFAQs(ApplicationDbContext context)
    {
        if (!context.FAQs.Any())
        {
            var faqs = new[]
            {
                new FAQ
                {
                    Question = "Si mund të blej një biletë?",
                    Answer = "Mund të blini biletë direkt në faqen e eventit ose në pikën e shitjes.",
                  
                },
                new FAQ
                {
                    Question = "A mund të anuloj një blerje?",
                    Answer = "Politika e anulimit varet nga organizatori i eventit.",
                   
                }
            };

            await context.FAQs.AddRangeAsync(faqs);
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedOrganizerProfiles(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        if (!context.OrganizerProfiles.Any())
        {
            var organizer = await userManager.FindByEmailAsync("organizer@example.com");

            if (organizer != null)
            {
                var profile = new OrganizerProfile
                {
                    UserId = organizer.Id,
                    OrganizationName = "Organizata Jonë",
                    Bio = "Organizator i eventeve me eksperiencë",
                    Website = "https://organizatajone.com",
                    
                };

                await context.OrganizerProfiles.AddAsync(profile);
                await context.SaveChangesAsync();
            }
        }
    }
}