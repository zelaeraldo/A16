using A16.Models;
using Microsoft.AspNetCore.Identity;

public class PaymentTransaction
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }

    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string PaymentStatus { get; set; } // p.sh. "Paid", "Failed"
}
