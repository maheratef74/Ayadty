using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Treatment;

namespace presentationLayer.Models.Treament.ActionRequest;

public class CreateTreatmentAR
{
    [Required(ErrorMessage = "MedicineNameIsRequired")]
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
    public static CreateTreatmentAR ToTreatmentAr(this TreatmentDetailsDto treatmentDetailsDto)
    {
        return new CreateTreatmentAR()
        {
            MedicineName = treatmentDetailsDto.Name,
            Dosage = treatmentDetailsDto.Dosage,
            Note = treatmentDetailsDto.Note
        };
    }
    public static List<CreateTreatmentAR> ToTreatmentAR(this IEnumerable<TreatmentDetailsDto> treatmentDetailsDtos)
    {
        return treatmentDetailsDtos.Select(t => t.ToTreatmentAr()).ToList();
    }
}