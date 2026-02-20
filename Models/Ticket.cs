using A16.Models;

public class Ticket
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }

    public string TicketType { get; set; } // p.sh. "VIP", "General"
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
}
