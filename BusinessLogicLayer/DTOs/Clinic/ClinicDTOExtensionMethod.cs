
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs.Clinic;

public static class ClinicDTOExtensionMethod
{
    public static ClinicDetailsDto ToClinicDetailsDto(this CliniC   clinic)
    {
        var clinicDto = new ClinicDetailsDto()
        {
            
            Email=clinic.Email,
            PhoneNumber=clinic.PhoneNumber,
            Location=clinic.Location,
            Name=clinic.Name,
            ProfilePhoto=clinic.ProfilePhoto,
          
        };
        return clinicDto;
    }
}