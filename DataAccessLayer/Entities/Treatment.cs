using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities;

public class Treatment
{
    [Key]
    public int TreatmentId { get; set; }
    public string Name { get; set; }
    public string? Dosage { get; set; }
    public string? Note { get; set; }
    [ForeignKey("Prescription")]
    public string PrescriptionId { set; get; } // fk from prescription table 
}
