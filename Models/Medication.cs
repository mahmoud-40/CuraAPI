using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cura.Models
{
    public class Medication
    {
        [Key]
        public int MedId { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public DateTime? ReminderTime { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
