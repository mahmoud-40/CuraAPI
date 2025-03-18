using Cura.Models;

namespace Cura.DTOs
{
    public class SendDTO
    {
        public string UserId { get; set; } = null!;
        public string Message { get; set; } = null!;
        public int? RelatedId { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}