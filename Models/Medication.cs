using System.ComponentModel.DataAnnotations.Schema;

namespace Cura.Models
{
    public class Medication
    {
        public int MedId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public DateTime? ReminderTime { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
