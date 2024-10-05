using BusinessLogicLayer.DTOs.Prescription;
using DataAccessLayer.Entities;
namespace BusinessLogicLayer.Services.Prescription;

public interface IPrescriptionService
{
    Task<DataAccessLayer.Entities.Prescription> AddPrescription(PrescriptionDetailsDto prescriptionDetailsDto);

    Task<PrescriptionDetailsDto?> GetPrescriptionById(string PrescriptionId);
    Task UpdatePrescription(PrescriptionDetailsDto prescriptionDetailsDto);

    Task<List<PrescriptionDetailsDto>> GetPrescriptionsByAppointmentId(string appointmentId);
}