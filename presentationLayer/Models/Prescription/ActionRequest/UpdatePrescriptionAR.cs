using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Prescription;
using presentationLayer.Models.Treament.ActionRequest;

namespace presentationLayer.Models.Prescription.ActionRequest;

public class UpdatePrescriptionAR
{
    public string AppointmentId { get; set; }
    public string PrescriptionId { get; set; }
    [Required(ErrorMessage = "NameRequired")]
    public string PatientName { get; set; }
    public string PatientId { get; set; }
    
    [Required(ErrorMessage = "AgeRequired")]
    public int patientAge { get; set; } 
    
    [Required(ErrorMessage = "DateRequired")]
    public DateTime Date { get; set; }
    public string? Diagnosis { get; set; }

    public List<CreateTreatmentAR> Treatments { get; set; } = new List<CreateTreatmentAR>();
    
    public string? Notes { get; set; }

}
public static class UpdatePrescrptionARExtention
{
    public static UpdatePrescriptionAR ToPrescriptionDetailsAR(this PrescriptionDetailsDto prescriptionDetailsDto)
    {
        return new UpdatePrescriptionAR()
        {
            PatientId = prescriptionDetailsDto.PatientId,
            PrescriptionId = prescriptionDetailsDto.PrescriptionId,
            Date = prescriptionDetailsDto.Date,
            AppointmentId = prescriptionDetailsDto.AppointmentId,
            PatientName = prescriptionDetailsDto.PatientName,
            Notes = prescriptionDetailsDto.Notes,
            patientAge = prescriptionDetailsDto.patientAge,
            Diagnosis = prescriptionDetailsDto.Diagnosis,
            Treatments = prescriptionDetailsDto.Treatments
                .Select(t => t.ToTreatmentAr()).ToList()
        };
    }
    public static PrescriptionDetailsDto ToPrescriptionDetailsDto(this UpdatePrescriptionAR updatePrescriptionAr)
    {
        return new PrescriptionDetailsDto()
        {
            PatientId = updatePrescriptionAr.PatientId,
            PrescriptionId = updatePrescriptionAr.PrescriptionId,
            Date = updatePrescriptionAr.Date,
            AppointmentId = updatePrescriptionAr.AppointmentId,
            PatientName = updatePrescriptionAr.PatientName,
            Notes = updatePrescriptionAr.Notes,
            patientAge = updatePrescriptionAr.patientAge,
            Diagnosis = updatePrescriptionAr.Diagnosis,
            Treatments = updatePrescriptionAr.Treatments.Select(t => t.ToTreatmentDto()).ToList()
        };
    }
}