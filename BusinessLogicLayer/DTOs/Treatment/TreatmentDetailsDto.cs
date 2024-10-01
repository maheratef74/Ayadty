namespace BusinessLogicLayer.DTOs.Treatment;
using DataAccessLayer.Entities;
public class TreatmentDetailsDto
{
    public string TreatmentId { get; set; }
    public string PrescriptionId { set; get; } 
    public string Name { get; set; }
    public string? Dosage { get; set; }
    public string? Note { get; set; }
}
public static class TreatmentDetailsExtension
{
    public static Treatment ToTreatment(this TreatmentDetailsDto treatmentDetailsDto)
    {
        return new Treatment()
        {
            Name = treatmentDetailsDto.Name,
            PrescriptionId = treatmentDetailsDto.PrescriptionId,
            TreatmentId = Guid.NewGuid().ToString(),
            Dosage = treatmentDetailsDto.Dosage,
            Note = treatmentDetailsDto.Note
        };
    }
    public static TreatmentDetailsDto ToTreatmentDto(this Treatment treatment)
    {
        return new TreatmentDetailsDto()
        {
            Name = treatment.Name,
            PrescriptionId = treatment.PrescriptionId,
            TreatmentId = treatment.TreatmentId,
            Dosage = treatment.Dosage,
            Note = treatment.Note
        };
    }
}