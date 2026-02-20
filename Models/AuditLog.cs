public class AuditLog
{
    public int Id { get; set; }
    public string ActionType { get; set; }
    public string UserId { get; set; }
    public string EntityName { get; set; }
    public string EntityId { get; set; }
    public DateTime ActionDate { get; set; }
}
