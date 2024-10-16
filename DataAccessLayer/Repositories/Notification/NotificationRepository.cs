using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Notification;
using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
public class NotificationRepository : INotificationRepository
{
    private readonly AppDbContext _appDbContext;

    public NotificationRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task CreateNotification(Notification notification)
    {
        notification.NotificationId = Guid.NewGuid().ToString();
        await _appDbContext.Notifications.AddAsync(notification);
    }

    public async Task<List<Notification>> GetUnreadNotifications()
    {
        var notifications = _appDbContext.Notifications.Where(n => n.IsRead == false).ToList();

        return notifications;
    }

    public async Task MarkAllAsRead()
    {
        var unreadNotifications = await _appDbContext.Notifications
            .Where(n => !n.IsRead)
            .ToListAsync();

        foreach (var notification in unreadNotifications)
        {
            notification.IsRead = true; 
        }
    }

    public async Task SaveChange()
    {
        await _appDbContext.SaveChangesAsync();
    }
}