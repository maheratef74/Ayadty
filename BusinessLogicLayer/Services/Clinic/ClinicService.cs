
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
    private readonly AppDbContext _appDbContext;


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

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }

    public async Task UpdateClinic(UpdateClinicDto updateClinicDto)
    {
        var clinic = updateClinicDto.ToUpdatedClinic();

        if (clinic is not null)
        {
            await _clinicRepository.SaveChanges();
            await _clinicRepository.Update(clinic);
        }
    }

    public Task UpdateClinic(string clinicId)
    {
        throw new NotImplementedException();
    }
}