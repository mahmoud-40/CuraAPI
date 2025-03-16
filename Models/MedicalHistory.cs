namespace Cura.Models
{
    public class MedicalHistory
    {
        public int MedicalHistoryId { get; set; }
        public string? Condition { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }
        public DateTime? Date { get; set; }
        
        public virtual ApplicationUser? User { get; set; }
    }
}
