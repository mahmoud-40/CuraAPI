using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Cura.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        [ForeignKey("ProfileImage")]
        public int? ImageId { get; set; }
        public virtual Image? ProfileImage { get; set; }

        public virtual List<Medication> Medications { get; set; } = new List<Medication>();
        public virtual List<Message> Messages { get; set; } = new List<Message>();
        public virtual List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
