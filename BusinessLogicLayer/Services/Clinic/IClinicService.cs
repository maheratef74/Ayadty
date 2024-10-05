using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Clinic;

namespace BusinessLogicLayer.Services.Clinic;

public interface IClinicService
{
    Task<ClinicDetailsDto?> GetClinicById(string Id);
    Task UpdateClinic(UpdateClinicDto UpdateclinicDetailsDto);
}