using DataAccessLayer.Repositories.Doctor;

namespace BusinessLogicLayer.Services.Doctor;
using BusinessLogicLayer.DTOs.Doctor;
public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    public async Task<DoctorDetailsDto?> GetDoctorById(string Id)
    {
        var doctor = await _doctorRepository.GetById(Id);
        if (doctor == null)
            return null;

        return doctor.ToDoctorDto();
    }
    public async Task UpdateDoctor(UpdateDoctorDto updateDoctorDto)
    {
        var doctor = updateDoctorDto.ToUpdateDoctor();

        if (doctor is not null)
        {
            await _doctorRepository.Update(doctor);
            await _doctorRepository.SaveChange();
        }
    }

    public async Task DeleteDoctor(string doctorId)
    {
        await _doctorRepository.Delete(doctorId);
        await _doctorRepository.SaveChange();
    }

    public Task UpdateDoctor(string doctorId)
    {
        throw new NotImplementedException();
    }
}