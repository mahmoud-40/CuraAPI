using Azure;
using Cura.DTOs;
using Cura.Models;

namespace Cura.Data.Interface
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<IEnumerable<GetNotificationDTO>> GetUserNotifications(string userId, bool onlyUnread = false);
        Task MarkAsRead(int notificationId);
        Task DeleteUserNotifications(string userId);
        Task<Configuration.Response<string>> Send(SendDTO send);
    }
}
