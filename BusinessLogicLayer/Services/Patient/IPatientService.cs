using BusinessLogicLayer.DTOs.Ptient;

namespace BusinessLogicLayer.Services.Patient;

public interface IPatientService
{
    Task<PatientDetailsDto> GetPatientById(int Id);
}