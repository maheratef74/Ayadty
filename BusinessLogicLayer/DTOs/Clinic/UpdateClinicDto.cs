using System.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs.Clinic;
using DataAccessLayer.Entities;
public class UpdateClinicDto
{
    public string clinicId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; }
    public List<WorkDay> DaysOfWork { get; set; }

}

public static class UpdateClinicExtensionMethold
{
    public static Clinic? ToUpdatedClinic(this UpdateClinicDto? updateClinicDto)
    {
        if (updateClinicDto == null )
        {
            return null;
        }
       
        var Clinic = new Clinic()
        {
            ClinicId = "1",
            Name = updateClinicDto.Name,
            Location = updateClinicDto.Location,
            PhoneNumber = updateClinicDto.PhoneNumber,
            Email = updateClinicDto.Email,
            ProfilePhoto = updateClinicDto.ProfilePhoto
        };
        return Clinic;
    }
}