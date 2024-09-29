using BusinessLogicLayer.DTOs.Prescription;
using presentationLayer.Models.Treament.ActionRequest;

namespace presentationLayer.Models.Prescription.ActionRequest;

public class CreatePrescrptionAR
{
    public string AppointmentId { get; set; }
    public string PatientName { get; set; } 
    public int patientAge { get; set; }
    public DateTime Date { get; set; }

    public List<CreateTreatmentAR> Treatments { get; set; } = new List<CreateTreatmentAR>();
    
    public string? Notes { get; set; }
}

public static class CreatePrescrptionARExtention
{
    public static PrescriptionDetailsDto ToPrescriptionDetailsDto(this CreatePrescrptionAR createPrescrptionAr)
    {
        return new PrescriptionDetailsDto()
        {
            Date = createPrescrptionAr.Date,
            PatientName = createPrescrptionAr.PatientName,
            Notes = createPrescrptionAr.Notes,
            patientAge = createPrescrptionAr.patientAge,
            Treatments = createPrescrptionAr.Treatments.Select(t => t.ToTreatmentDto()).ToList()
        };
    }
}