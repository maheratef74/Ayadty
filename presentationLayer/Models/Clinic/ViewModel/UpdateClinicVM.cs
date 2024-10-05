using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Clinic;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTOs.Appointment;

namespace presentationLayer.Models.Clinic.ViewModel;
    public class UpdateClinicVM
    {
        public string? Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? ProfilePhoto { get; set; }
        public string location { get; set; }
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