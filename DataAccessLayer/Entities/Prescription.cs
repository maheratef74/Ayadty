using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayadty.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; } // Primary Key
        
     /*   [ForeignKey("Patient")]
        public int PatientId { get; set; }// Foreign Key
        public Patient Patient { get; set; }*/// Navigation property
        
        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; } // Foreign Key
        public MedicalRecord MedicalRecord { get; set; } // Navigation property

        public DateTime Date { get; set; }

        public List<Treatment> Treatments { get; set; } = new List<Treatment>();
        
        [MaxLength(450)]
        public string? Notes { get; set; }
    }
}