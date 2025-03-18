using AutoMapper;
using Azure;
using Cura.Data.Interface;
using Cura.DTOs;
using Cura.Models;
using Microsoft.EntityFrameworkCore;
using Cura.Configuration;

namespace Cura.Data.Repository
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NotificationRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetNotificationDTO>> GetUserNotifications(string userId, bool onlyUnread = false)
        {
            var notifications = _context.Notifications
                .Where(n => n.UserId == userId && (!onlyUnread || !n.IsSeen))
                .OrderByDescending(n => n.SentAt);

            return _mapper.Map<IEnumerable<GetNotificationDTO>>(await notifications.ToListAsync());
        }

        public async Task MarkAsRead(int notificationId)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(n => n.NotificationId == notificationId);
            if (notification != null)
            {
                notification.IsSeen = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserNotifications(string userId)
        {
            await _context.Notifications.Where(n => n.UserId == userId).ExecuteDeleteAsync();
        }

        public async Task<Configuration.Response<string>> Send(SendDTO send)
        {
            var notification = _mapper.Map<Notification>(send);
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return new Configuration.Response<string>
            {
                Data = "Notification sent successfully",
                Message = "Notification sent successfully",
                Success = true
            };
        }
    }
}
