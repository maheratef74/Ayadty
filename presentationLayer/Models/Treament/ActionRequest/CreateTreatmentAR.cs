using BusinessLogicLayer.DTOs.Treatment;

namespace presentationLayer.Models.Treament.ActionRequest;

public class CreateTreatmentAR
{
    public string MedicineName  { get; set; }
    public string? Dosage { get; set; }
    public string? Note { get; set; }
}
public static class TreatmentARExtension
{
    public static TreatmentDetailsDto ToTreatmentDto(this CreateTreatmentAR treatmentDetailsAR)
    {
        return new TreatmentDetailsDto()
        {
            Name = treatmentDetailsAR.MedicineName,
            Dosage = treatmentDetailsAR.Dosage,
            Note = treatmentDetailsAR.Note
        };
    }
    public static List<TreatmentDetailsDto> ToTreatment(this IEnumerable<CreateTreatmentAR> treatmentDetailsAR)
    {
        return treatmentDetailsAR.Select(t => t.ToTreatmentDto()).ToList();
    }
}