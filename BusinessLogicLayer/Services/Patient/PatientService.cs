using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Repositories.Patient;
using Microsoft.VisualBasic;
namespace BusinessLogicLayer.Services.Patient;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientDetailsDto?> GetPatientById(int id)
    {
        var patient = await _patientRepository.GetById(id);
        if (patient is null)  return null;
        
        return patient.ToPatientDetailsDto();
    }

    public async Task<PatientDetailsDto> GetPatientByPhoneNumber(string phoneNumber)
    {
        var patient = await _patientRepository.GetPatientByPhoneNUmber(phoneNumber);
        if (patient is null) return null;

        return patient.ToPatientDetailsDto();
    }
}