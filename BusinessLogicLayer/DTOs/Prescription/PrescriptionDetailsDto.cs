namespace BusinessLogicLayer.DTOs.Prescription;

public class PrescriptionDetailsDto
{
    public int PrescriptionId { get; set; } // Primary Key
    
    public DateTime Date { get; set; }
    
    
    public string? Notes { get; set; }
}