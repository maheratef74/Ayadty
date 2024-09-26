using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;

namespace presentationLayer.Models.Patient.ViewModel;

public class UpdatePatientVM
{
    public string PatientId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Enums.Gender Gender { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; }
    public string password { get; set; }
    public string? FacebookProfile { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string ProfilePhoto { get; set; }
}
public static class UpdatePatientExtenionMethod
{
    public static UpdatePatientDto ToUpdatePatientDto(this UpdatePatientVM vm)
    {
        return new UpdatePatientDto
        {
            PatientId = vm.PatientId,
            DateOfBirth = vm.DateOfBirth,
            FullName = vm.FullName,
            Phone = vm.Phone,
            FacebookProfile = vm.FacebookProfile,
            Gender = vm.Gender,
            Email = vm.Email,
            Address = vm.Address,
            ProfilePhoto = vm.ProfilePhoto,
        };

    }
    public static UpdatePatientVM ToUpdatePatientVM(this PatientDetailsDto dto)
    {
        return new UpdatePatientVM
        {
            PatientId= dto.PatientId,
            FullName = dto.Name,
            Phone = dto.PhoneNumber,
            FacebookProfile = dto.FacbookProfile,
            Gender = dto.Gender,
            Email = dto.Email,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            ProfilePhoto = dto.ProfilePhoto,
        };
    }
}
