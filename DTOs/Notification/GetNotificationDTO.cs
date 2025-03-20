using Cura.Models;
using System;

namespace Cura.DTOs
{
    public class GetNotificationDTO
    {
        public int NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? SentAt { get; set; }
        public bool IsSeen { get; set; }
        public NotificationType? NotificationType { get; set; }
    }
}