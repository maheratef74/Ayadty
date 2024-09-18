using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Patient;
using BusinessLogicLayer.DTOs.Ptient;

namespace BusinessLogicLayer.Services.Patient;

public interface IPatientService
{
    Task<PatientDetailsDto> GetPatientById(int Id);
    Task AddPatient(AddPatientDto addPatientDto);

}