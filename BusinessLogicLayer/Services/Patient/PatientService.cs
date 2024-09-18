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
        var _patient = await _patientRepository.GetById(4);
        var PatientDto = new PatientDetailsDto()
        {
            PatientId = _patient.Id,
            Name = _patient.Name,
            PhoneNumber = _patient.PhoneNumber,
            ProfilePhoto = _patient.ProfilePhoto,
            Gender = _patient.Gender,
            Email = _patient.Email,
            Address = _patient.Address,
            DateOfBirth = _patient.DateOfBirth,
            FacbookProfile = _patient.FacbookProfile
        };
        return PatientDto;
    }
}