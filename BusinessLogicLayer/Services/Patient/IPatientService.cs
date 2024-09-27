using BusinessLogicLayer.DTOs.Ptient;

namespace BusinessLogicLayer.Services.Patient;

public interface IPatientService
{
    Task<PatientDetailsDto?> GetPatientById(string Id);
    Task<PatientDetailsDto> GetPatientByPhoneNumber(string phoneNumber);
    Task UpdatePatient(UpdatePatientDto updatePatientDto);
}