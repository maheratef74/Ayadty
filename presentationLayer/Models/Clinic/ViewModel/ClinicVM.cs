using BusinessLogicLayer.DTOs.Clinic;
using DataAccessLayer.Entities;
using presentationLayer.Models.Auth.ActionRequest;
using System.ComponentModel.DataAnnotations;
namespace presentationLayer.Models.Clinic.ViewModel;

public  class ClinicVM
{
    
    public string ClinicId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; }
    public List<WorkDay> DaysOfWork { get; set; }
}
public static  class ClinicVmExtensions
{
    public static ClinicVM ToClinicVM(this ClinicDetailsDto dto)
    {
        return new ClinicVM
        {
            Name = dto.Name,
            Location= dto.Location,
          
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            ProfilePhoto = dto.ProfilePhoto,
    
          
        };
    }
    

}

