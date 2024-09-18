using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Patient;
using BusinessLogicLayer.DTOs.Prescription;
using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;
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
            PatientId = _patient.PatientId,
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
    public async Task AddPatient(AddPatientDto addPatientDto)
    {
        var Patient = new DataAccessLayer.Entities.Patient()
        {
            Name = addPatientDto.Name,
            PhoneNumber = addPatientDto.PhoneNumber,
            Address = addPatientDto.Address,
            DateOfBirth = (DateTime)addPatientDto.DateOfBirth,
            Password = addPatientDto.Password,
            Gender = addPatientDto.Gender

        };
        await _patientRepository.Add(Patient);
        await _patientRepository.SaveChanges();
        
    }

    
}