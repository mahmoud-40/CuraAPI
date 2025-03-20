using System.ComponentModel.DataAnnotations.Schema;

namespace Cura.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? RelatedId { get; set; } 
        public NotificationType? NotificationType { get; set; }
        public DateTime? SentAt { get; set; } = DateTime.Now;
        public bool IsSeen { get; set; } = false;
        
        public virtual ApplicationUser? User { get; set; }
    }

    public enum NotificationType
    {
        MedicationReminder,
        GeneralAlert,
        SystemNotification
    }
}
