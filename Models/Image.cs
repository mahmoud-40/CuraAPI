using System.ComponentModel.DataAnnotations.Schema;

namespace Cura.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string? Path { get; set; }
        
        [ForeignKey("User")]
        public string? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
