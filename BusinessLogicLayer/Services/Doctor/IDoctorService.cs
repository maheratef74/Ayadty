namespace BusinessLogicLayer.Services.Doctor;
using BusinessLogicLayer.DTOs.Doctor;
public interface IDoctorService
{
    Task<DoctorDetailsDto> GetDoctorById(string Id);
}