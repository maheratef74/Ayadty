namespace BusinessLogicLayer.Services.Notification;
using DataAccessLayer.Entities;
public interface INotificationService
{
    Task CreateNotification(string message);
    Task<List<Notification>> GetUnreadNotifications();
    Task MarkAllAsRead();
}