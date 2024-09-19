using BusinessLogicLayer.DTOs.Prescription;
using BusinessLogicLayer.DTOs.Treatment;
using DataAccessLayer.Repositories.Prescription;
using DataAccessLayer.Entities;
namespace BusinessLogicLayer.Services.Prescription;

public class PrescriptionService : IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }

    public async Task AddPrescription(PrescriptionDetailsDto prescriptionDetailsDto)
    {
        var prescription = new DataAccessLayer.Entities.Prescription()
        {
            Date = prescriptionDetailsDto.Date,
            UserId = 2,
            Notes = prescriptionDetailsDto.Notes,
            patientAge =prescriptionDetailsDto.patientAge,
            PatientName = prescriptionDetailsDto.PatientName,
            
            Treatments = prescriptionDetailsDto.Treatments.Select(t => t.ToTreatment()).ToList()
        };
        await _prescriptionRepository.Add(prescription);
        await _prescriptionRepository.SaveChanges();
    }
}