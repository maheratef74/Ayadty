using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayadty.Models;

public class Treatment
{
    [Key]
    public int TreatmentId { get; set; }
    public string Name { get; set; }
    
    [ForeignKey("Prescription")]
    public int PrescriptionId { set; get; } // fk from prescription table 
}