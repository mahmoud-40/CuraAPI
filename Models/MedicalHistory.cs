using System.ComponentModel.DataAnnotations.Schema;

namespace Cura.Models
{
    public class MedicalHistory
    {
        public int MedicalHistoryId { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public string? Condition { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        
        public virtual ApplicationUser? User { get; set; }
    }
}
