using BusinessLogicLayer.Services.Notification;
using Microsoft.AspNetCore.Mvc;

public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    // GET: /Notification/GetUnreadNotifications
    public async Task<IActionResult> GetUnreadNotifications()
    {
        var notifications = await _notificationService.GetUnreadNotifications();
        var formattedNotifications = notifications.Select(not => new
        {
            not.NotificationId,
            not.Message,
            CreatedAt = not.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"), 
            not.IsRead,
        }).ToList();

        return Json(formattedNotifications);
    }

    [HttpPost]
    public async Task<IActionResult> MarkAllAsRead()
    {
        await _notificationService.MarkAllAsRead();
        return Ok(); 
    }
}