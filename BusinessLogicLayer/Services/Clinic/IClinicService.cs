using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Clinic;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Services.Clinic;

public interface IClinicService
{
    Task<ClinicDetailsDto?> GetClinicById(string Id);
    Task UpdateClinic(UpdateClinicDto UpdateclinicDetailsDto);




   
    
        Task<string> SavePhotoPathAsync(IFormFile photo, string clinicId);
    

}