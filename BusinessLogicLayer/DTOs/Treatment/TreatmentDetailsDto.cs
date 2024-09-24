namespace BusinessLogicLayer.DTOs.Treatment;
using DataAccessLayer.Entities;
public class TreatmentDetailsDto
{
    public string TreatmentId { get; set; }
    public string Name { get; set; }
    public string? Dosage { get; set; }
    public string? Note { get; set; }
    public string PrescriptionId { set; get; } 
}

public static class TreatmentDetailsExtension
{
    public static Treatment ToTreatment(this TreatmentDetailsDto treatmentDetailsDto)
    {
        return new Treatment()
        {
            Name = treatmentDetailsDto.Name,
            PrescriptionId = treatmentDetailsDto.PrescriptionId,
            TreatmentId = treatmentDetailsDto.TreatmentId,
            Dosage = treatmentDetailsDto.Dosage,
            Note = treatmentDetailsDto.Note
        };
    }
    public static List<Treatment> ToTreatment(this IEnumerable<TreatmentDetailsDto> treatmentDetailsDtos)
    {
        return treatmentDetailsDtos.Select(t => t.ToTreatment()).ToList();
    }
}