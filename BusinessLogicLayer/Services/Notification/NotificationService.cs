using DataAccessLayer.Repositories.Notification;

namespace BusinessLogicLayer.Services.Notification;
using DataAccessLayer.Entities;
public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task CreateNotification(string message)
    {
        // Create a notification for the doctor
        var notifaction = new Notification()
        {
            Message = message,
            CreatedAt = DateTime.Now,
            IsRead = false
        };
        await _notificationRepository.CreateNotification(notifaction);
        await _notificationRepository.SaveChange();
    }

    
    public async Task<List<Notification>> GetUnreadNotifications()
    {
        var notifications = await _notificationRepository.GetUnreadNotifications();

        return notifications;
    }

    public async Task MarkAllAsRead()
    {
        await _notificationRepository.MarkAllAsRead();
        await _notificationRepository.SaveChange();
    }
}