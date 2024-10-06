using BusinessLogicLayer.DTOs.Treatment;

namespace BusinessLogicLayer.DTOs.Prescription;
using DataAccessLayer.Entities;
public class PrescriptionDetailsDto
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
}
public static class prescriptionExtensionMethold
{
    public static Prescription ToPrescription(this PrescriptionDetailsDto prescriptionDetailsDto)
    {
        return new Prescription()
        {
            AppointmentId = prescriptionDetailsDto.AppointmentId,
            PrescriptionId = Guid.NewGuid().ToString(),
            UserId = prescriptionDetailsDto.PatientId,
            PatientName = prescriptionDetailsDto.PatientName,
            patientAge = prescriptionDetailsDto.patientAge,
            Date = prescriptionDetailsDto.Date,
            Treatments = prescriptionDetailsDto.Treatments
                .Select(t => t.ToTreatment()).ToList(), // Convert each TreatmentDetailsDto to Treatment
            Diagnosis = prescriptionDetailsDto.Diagnosis,
            Notes = prescriptionDetailsDto.Notes
        };
    }
    public static Prescription ToUpdatedPrescription(this PrescriptionDetailsDto UpdatedprescriptionDetailsDto)
    {
        return new Prescription()
        {
            AppointmentId = UpdatedprescriptionDetailsDto.AppointmentId,
            PrescriptionId = UpdatedprescriptionDetailsDto.PrescriptionId,
            UserId = UpdatedprescriptionDetailsDto.PatientId,
            PatientName = UpdatedprescriptionDetailsDto.PatientName,
            patientAge = UpdatedprescriptionDetailsDto.patientAge,
            Date = UpdatedprescriptionDetailsDto.Date,
            Treatments = UpdatedprescriptionDetailsDto.Treatments
                .Select(t => t.ToTreatment()).ToList(), // Convert each TreatmentDetailsDto to Treatment
            Diagnosis = UpdatedprescriptionDetailsDto.Diagnosis,
            Notes = UpdatedprescriptionDetailsDto.Notes
        };
    }
    public static PrescriptionDetailsDto ToPrescriptionDto(this Prescription prescription)
    {
        return new PrescriptionDetailsDto()
        {
            AppointmentId = prescription.AppointmentId,
            PrescriptionId = prescription.PrescriptionId,
            PatientId = prescription.UserId,
            PatientName = prescription.PatientName,
            patientAge = prescription.patientAge,
            Date = prescription.Date,
            Treatments = prescription.Treatments
                .Select(t => t.ToTreatmentDto()).ToList(), // Convert each Treatment to TreatmentDetailsDto 
            Diagnosis = prescription.Diagnosis,
            Notes = prescription.Notes
        };
    }
}