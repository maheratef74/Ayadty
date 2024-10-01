using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Prescription;
using presentationLayer.Models.Treament.ActionRequest;

namespace presentationLayer.Models.Prescription.ActionRequest;

public class UpdatePrescriptionAR
{
    public string AppointmentId { get; set; }
    [Required(ErrorMessage = "NameRequired")]
    public string PatientName { get; set; }
    public string PatientId { get; set; }
    
    [Required(ErrorMessage = "AgeRequired")]
    public int patientAge { get; set; } 
    
    public DateTime Date { get; set; }
    public string? Diagnosis { get; set; }

    public List<CreateTreatmentAR> Treatments { get; set; } = new List<CreateTreatmentAR>();
    
    public string? Notes { get; set; }

}
public static class UpdatePrescrptionARExtention
{
    public static UpdatePrescriptionAR ToPrescriptionDetailsDto(this PrescriptionDetailsDto prescriptionDetailsDto)
    {
        return new UpdatePrescriptionAR()
        {
            PatientId = prescriptionDetailsDto.PatientId,
            Date = prescriptionDetailsDto.Date,
            AppointmentId = prescriptionDetailsDto.AppointmentId,
            PatientName = prescriptionDetailsDto.PatientName,
            Notes = prescriptionDetailsDto.Notes,
            patientAge = prescriptionDetailsDto.patientAge,
            Treatments = prescriptionDetailsDto.Treatments
                .Select(t => t.ToTreatmentAr()).ToList()
        };
    }
}