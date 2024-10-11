using BusinessLogicLayer.DTOs.Prescription;
using BusinessLogicLayer.DTOs.Treatment;

namespace presentationLayer.Models.Prescription.ViewModel;

public class PrescriptionsVM
{
    public string PrescriptionId { get; set; } 
    public string PatientId { get; set; }
    public string AppointmentId { get; set; }
    public string PatientName { get; set; } 
    public int patientAge { get; set; }
    
    public string? Diagnosis { get; set; }
    public DateTime Date { get; set; }

    public List<TreatmentDetailsDto> Treatments { get; set; } = new List<TreatmentDetailsDto>();
    
    public string? Notes { get; set; }
    public List<string> DaysOfWork { get; set; }
    public  string clinicAdress { get; set; }
    public string clinicPhone { get; set; }
}

public static class prescriptionExtensionMethold
{
    public static PrescriptionsVM ToPrescriptionsVm(this PrescriptionDetailsDto prescriptionDetailsDto)
    {
        return new PrescriptionsVM()
        {
            PrescriptionId = prescriptionDetailsDto.PrescriptionId,
            AppointmentId = prescriptionDetailsDto.PrescriptionId,
            PatientId = prescriptionDetailsDto.PatientId,
            PatientName = prescriptionDetailsDto.PatientName,
            patientAge = prescriptionDetailsDto.patientAge,
            Date = prescriptionDetailsDto.Date,
            Diagnosis = prescriptionDetailsDto.Diagnosis,
            Notes = prescriptionDetailsDto.Notes,
            Treatments = prescriptionDetailsDto.Treatments
        };
    }
}