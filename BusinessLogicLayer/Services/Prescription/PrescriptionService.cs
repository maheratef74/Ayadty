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
    public async Task UpdatePrescription(PrescriptionDetailsDto UpdatedprescriptionDetailsDto)
    {
        var updatedPrescription = UpdatedprescriptionDetailsDto.ToUpdatedPrescription();
        await _prescriptionRepository.UpdatePrescription(updatedPrescription);
        await _prescriptionRepository.SaveChanges();
    }

    public async Task<List<PrescriptionDetailsDto>> GetPrescriptionsByAppointmentId(string appointmentId)
    {
        var prescriptions = await _prescriptionRepository.GetPrescriptionsByAppointmentId(appointmentId);
        var prescriptionsDto = new List<PrescriptionDetailsDto>();

        foreach (var prescription in prescriptions)
        {
            var prescriptionDto = prescription.ToPrescriptionDto();
            prescriptionsDto.Add(prescriptionDto);
        }

        return prescriptionsDto;
    }
}