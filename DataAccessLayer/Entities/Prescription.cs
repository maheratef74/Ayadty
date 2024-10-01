using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Prescription
    {
        [Key]
        public string PrescriptionId { get; set; } // Primary Key
        public string AppointmentId { get; set; }
        
        [ForeignKey("Users")]
        public string UserId { get; set; }// Foreign Key
        public Patient? Patient { get; set; }// Navigation property
        public string PatientName { get; set; }
        public int patientAge { get; set; }
        public string? Diagnosis { get; set; }
        public DateTime Date { get; set; }

        public List<Treatment> Treatments { get; set; } = new List<Treatment>();
        
        [MaxLength(450)]
        public string? Notes { get; set; }
    }
}