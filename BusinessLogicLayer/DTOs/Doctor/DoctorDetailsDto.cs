namespace BusinessLogicLayer.DTOs.Doctor;
using DataAccessLayer.Entities;
public class DoctorDetailsDto
{
    public string DoctorId { get; set; } // Primary Key
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsAvalibleToAppoinment { get; set; }
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; }
    public int? YearsOfExperience { get; set; }
    public decimal? Price { get; set; }
}

public static class DoctorExtensionMethold
{
    public static DoctorDetailsDto ToDoctorDto(this Doctor doctor)
    {
        return new DoctorDetailsDto()
        {
            DoctorId = doctor.Id,
            Name = doctor.FullName,
            PhoneNumber = doctor.Phone,
            ProfilePhoto = doctor.ProfilePhoto,
            Price = doctor.Price,
            Email = doctor.Email,
            YearsOfExperience = doctor.YearsOfExperience
        };
    }
}