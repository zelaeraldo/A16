using A16.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using A16.Models;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AttendanceHistory> AttendanceHistories { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<EmailQueue> EmailQueues { get; set; }

    public DbSet<Event> Events { get; set; }
    public DbSet<EventCancellation> EventCancellations { get; set; }
    public DbSet<EventCategory> EventCategories { get; set; }
    public DbSet<EventDocument> EventDocuments { get; set; }
    public DbSet<EventFeedback> EventFeedbacks { get; set; }
    public DbSet<EventImage> EventImages { get; set; }
    public DbSet<EventRegistration> EventRegistrations { get; set; }
    public DbSet<EventScheduleItem> EventScheduleItems { get; set; }
    public DbSet<EventSponsor> EventSponsors { get; set; }
    public DbSet<EventTag> EventTags { get; set; }
    public DbSet<EventTagAssignment> EventTagAssignments { get; set; }
    public DbSet<FAQ> FAQs { get; set; }
    public DbSet<FavoriteEvent> FavoriteEvents { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }



  
}