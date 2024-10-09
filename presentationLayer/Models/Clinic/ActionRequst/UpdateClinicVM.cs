using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Clinic;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs.Appointment;

namespace presentationLayer.Models.Clinic.ViewModel;
    public class UpdateClinicVM
    {
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "ClinicNameRequired")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PhoneNumberRequired")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")]
        public string Phone { get; set; }
        public string? ProfilePhoto { get; set; }
        [Required(ErrorMessage = "AddressRequired")]
        public string location { get; set; }
        public IFormFile? FormFilePhoto { get; set; }

    }
public static class UpdateClinicExtenionMethod
{
    public static UpdateClinicDto ToUpdateClinicDto(this UpdateClinicVM vm)
    {
        return new UpdateClinicDto
        {
            Name = vm.Name,
            Email = vm.Email,
            Location = vm.location,
            PhoneNumber = vm.Phone,
            ProfilePhoto = vm.ProfilePhoto,
        };
    }
    public static UpdateClinicVM ToUpdateClinicVM(this ClinicDetailsDto dto)
    {
        return new UpdateClinicVM
        {
            Name = dto.Name,
            Email = dto.Email,
            location = dto.Location,
            Phone = dto.PhoneNumber,
            ProfilePhoto = dto.ProfilePhoto,
        };
    }
}