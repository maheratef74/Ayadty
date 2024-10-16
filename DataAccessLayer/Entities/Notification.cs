namespace DataAccessLayer.Entities;

public class Notification
{
    public string NotificationId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
}