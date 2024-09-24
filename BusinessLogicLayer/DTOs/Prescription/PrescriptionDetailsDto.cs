using BusinessLogicLayer.DTOs.Treatment;

namespace BusinessLogicLayer.DTOs.Prescription;
using DataAccessLayer.Entities;
public class PrescriptionDetailsDto
{
    public string PrescriptionId { get; set; } 
    public string PatientId { get; set; }
    
    public string PatientName { get; set; } 
    public string patientAge { get; set; }
    
    public DateTime Date { get; set; }

    public List<TreatmentDetailsDto> Treatments { get; set; } = new List<TreatmentDetailsDto>();
    
    public string? Notes { get; set; }
}