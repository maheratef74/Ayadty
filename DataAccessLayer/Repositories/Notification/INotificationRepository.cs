namespace DataAccessLayer.Repositories.Notification;
using DataAccessLayer.Entities;
public interface INotificationRepository
{
    Task CreateNotification(Notification notification);
    Task<List<Notification>> GetUnreadNotifications();
    Task MarkAllAsRead();
    Task SaveChange();
}