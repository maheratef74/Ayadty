using BusinessLogicLayer.DTOs.Prescription;

namespace BusinessLogicLayer.Services.Prescription;

public interface IPrescriptionService
{
    Task AddPrescription(PrescriptionDetailsDto prescriptionDetailsDto);
}