using BusinessLogicLayer.DTOs.Doctor;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Models.Doctor.ViewModel
{
    public class UpdateDoctorVM
    {
        public string DoctorId { get; set; } 
        
        [Required(ErrorMessage = "NameRequired")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PhoneNumberRequired")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")]
      //  [Remote(action: "CheckPhone", controller: "auth", AdditionalFields = nameof(DoctorId) ,
        //    ErrorMessage = "Use Another Phone Number")]
        public string PhoneNumber { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        public string? ProfilePhoto { get; set; }
        public IFormFile? FormFilePhoto { get; set; }
        public int? YearsOfExperience { get; set; }
        public int? Price { get; set; }
        public Enums.Gender Gender { get; set; }
        
        [DataType(DataType.Password)]
        [MinLength(6 , ErrorMessage = "PasswardAtLeast6Digit")]
        public string? Password { get; set; }
    
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage = "The two passwords do not match.")]
        public string? ConfirmPassword { get; set; }
    }

    public static class UpdateDoctorExtensionMethod
    {
        public static UpdateDoctorDto ToUpdateDoctorDto(this UpdateDoctorVM vm)
        {
            if (vm == null) return null;

            return new UpdateDoctorDto
            {
                DoctorId = vm.DoctorId,
                Name = vm.Name,  
                PhoneNumber = vm.PhoneNumber, 
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
                Name = dto.Name, 
                PhoneNumber = dto.PhoneNumber, 
                Email = dto.Email,
                ProfilePhoto = dto.ProfilePhoto,
                YearsOfExperience = dto.YearsOfExperience,
                Price = dto.Price
            };
        }
    }
}
