using BusinessLogicLayer.DTOs.Doctor;

namespace presentationLayer.Models.Doctor.ViewModel;

public class DoctorVM
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
public static class DoctorVmExtensions
{
    public static DoctorVM ToDoctorVM(this DoctorDetailsDto dto)
    {
        return new DoctorVM
        {
            DoctorId = dto.DoctorId,
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber,
            IsAvalibleToAppoinment=dto.IsAvalibleToAppoinment,
            Email = dto.Email,
            ProfilePhoto = dto.ProfilePhoto,
            YearsOfExperience=dto.YearsOfExperience,
            Price=dto.Price,
        };
    }
}
