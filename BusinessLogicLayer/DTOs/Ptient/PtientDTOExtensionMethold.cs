using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs.Ptient;

public static class PtientDTOExtensionMethold
{
    public static PatientDetailsDto ToPatientDetailsDto(this Patient patient)
    {
        var patientDto = new PatientDetailsDto()
        {
            PatientId = patient.Id,
            Name = patient.FullName,
            PhoneNumber = patient.Phone,
            ProfilePhoto = patient.ProfilePhoto,
            Gender = patient.Gender,
            Email = patient.Email,
            Address = patient.Address,
            DateOfBirth = patient.DateOfBirth,
            FacbookProfile = patient.FacbookProfile
        };
        return patientDto;
    }
}