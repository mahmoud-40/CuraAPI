using System.ComponentModel.DataAnnotations.Schema;

namespace Cura.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public string? Text { get; set; }
        public string? Response { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
