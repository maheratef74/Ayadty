namespace Ayadty.Models;

public class Treatment
{
    public int TreatmentId { get; set; }
    public string Name { get; set; }
    public int PrescriptionId { set; get; } // fk from prescription table 
}