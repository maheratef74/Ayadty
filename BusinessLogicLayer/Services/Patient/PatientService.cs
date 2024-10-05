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

    public async Task<PatientDetailsDto?> GetPatientById(string id)
    {
        var patient = await _patientRepository.GetById(id);
        if (patient is null) return null;

        return patient.ToPatientDetailsDto();
    }

    public async Task<PatientDetailsDto> GetPatientByPhoneNumber(string phoneNumber)
    {
        var patient = await _patientRepository.GetPatientByPhoneNUmber(phoneNumber);
        if (patient is null) return null;

        return patient.ToPatientDetailsDto();
    }
    public async Task UpdatePatient(UpdatePatientDto updatePatientDto)
    {
        var patient = updatePatientDto.ToUpdatePatient();

        if (patient is not null)
        {
            await _patientRepository.Update(patient);
            await _patientRepository.SaveChanges();
        }
    }

    public async Task<List<PatientDetailsDto>> GetPatientsByName(string searchTerm)
    {
        var patients = await _patientRepository.GetPatientsByName(searchTerm);
        var patientsDto = new List<PatientDetailsDto>();

        foreach (var patient in patients)
        {
            var patientDto = patient.ToPatientDetailsDto();
            patientsDto.Add(patientDto);
        }

        return patientsDto;
    }

    public async Task<List<PatientDetailsDto>> GetAllPatients()
    {
        var patients = await _patientRepository.GetAllPatients();
        var patientsDto = new List<PatientDetailsDto>();

        foreach (var patient in patients)
        {
            var patientDto = patient.ToPatientDetailsDto();
            patientsDto.Add(patientDto);
        }

        return patientsDto;
    }
    
}