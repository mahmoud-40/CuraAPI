using Cura.Models;
using System;

namespace Cura.DTOs
{
    public class GetNotificationDTO
    {
        public int NotificationId { get; set; }
        public string? Message { get; set; }
        public DateTime? SentAt { get; set; }
        public bool IsSeen { get; set; }
        public NotificationType? NotificationType { get; set; }
    }
}