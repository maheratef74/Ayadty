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

    public async Task<DataAccessLayer.Entities.Prescription> AddPrescription(PrescriptionDetailsDto prescriptionDetailsDto)
    {
        var prescription = prescriptionDetailsDto.ToPrescription();
        await _prescriptionRepository.Add(prescription);
        await _prescriptionRepository.SaveChanges();
        return prescription;
    }

    public async Task<PrescriptionDetailsDto?> GetPrescriptionById(string PrescriptionId)
    {
        var prescription = await _prescriptionRepository.GetPrescriptionById(PrescriptionId);

        var prescriptionDto = prescription.ToPrescriptionDto();
        return prescriptionDto;
    }
}