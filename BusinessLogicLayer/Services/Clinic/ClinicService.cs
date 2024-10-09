
using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Clinic;
using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Clinic;
using Microsoft.VisualBasic;
namespace BusinessLogicLayer.Services.Clinic;

public class ClinicService : IClinicService
{
    private readonly IClinicRepository _clinicRepository;

    public ClinicService(IClinicRepository clinicRepository)
    {
        _clinicRepository =  clinicRepository;
    }
    public async Task<ClinicDetailsDto?> GetClinicById(string id)
    {
        var clinic = await _clinicRepository.GetById(id);
        if (clinic is null) return null;
        var clinicdto = clinic.ToClinicDetailsDto();

        return clinicdto;
    }
    public async Task UpdateClinic(UpdateClinicDto updateClinicDto)
    {
        var clinic = updateClinicDto.ToUpdatedClinic();
        
         await _clinicRepository.Update(clinic);
         await _clinicRepository.SaveChanges();
    }

    public async Task OpenNewAppointments()
    {
        await _clinicRepository.OpenNewAppointments();
        await _clinicRepository.SaveChanges();
    }

    public async Task<bool> IsAvailbleToAppointment()
    {
        return await _clinicRepository.IsAvailabelToAppointments();
    }

    public async Task StopNewAppointment()
    {
        await _clinicRepository.StopNewAppointments();
        await _clinicRepository.SaveChanges();
    }
}