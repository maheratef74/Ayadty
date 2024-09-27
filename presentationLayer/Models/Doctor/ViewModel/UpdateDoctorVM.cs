using BusinessLogicLayer.DTOs.Doctor;

namespace presentationLayer.Models.Doctor.ViewModel
{
    public class UpdateDoctorVM
    {
        public string DoctorId { get; set; } 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAvailableForAppointment { get; set; }
        public string? Email { get; set; }
        public string? ProfilePhoto { get; set; }
        public int? YearsOfExperience { get; set; }
        public decimal? Price { get; set; }
    }

    public static class UpdateDoctorExtensionMethod
    {
        public static UpdateDoctorDto ToUpdateDoctorDto(this UpdateDoctorVM vm)
        {
            if (vm == null) return null;

            return new UpdateDoctorDto
            {
                DoctorId = vm.DoctorId,
                Name = vm.Name,  // Ensure this property exists in UpdateDoctorDto
                PhoneNumber = vm.PhoneNumber, // Ensure this property exists in UpdateDoctorDto
                Email = vm.Email,
                ProfilePhoto = vm.ProfilePhoto,
                YearsOfExperience = vm.YearsOfExperience,
                Price = vm.Price,
            };
        }

        public static UpdateDoctorVM? ToUpdateDoctorVM(this DoctorDetailsDto dto)
        {
            if (dto == null) return null;

            return new UpdateDoctorVM
            {
                DoctorId = dto.DoctorId,
                Name = dto.FullName, // Ensure this matches the property names in your DTOs
                PhoneNumber = dto.Phone, // Ensure this matches the property names in your DTOs
                Email = dto.Email,
                ProfilePhoto = dto.ProfilePhoto,
                YearsOfExperience = dto.YearsOfExperience,
                Price = dto.Price,
            };
        }
    }
}
