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
    public async Task<DoctorDetailsDto> GetDoctorById(string Id)
    {
        var _doctor = await _doctorRepository.GetById(Id);
        if (_doctor == null)
            return null;

        return _doctor.ToDoctorDto();
    }


    public async Task UpdateDoctor(UpdateDoctorDto updateDoctorDto)
    {
        var doctor = updateDoctorDto.ToUpdateDoctor();

        if (doctor is not null)
        {
            await _doctorRepository.Update(doctor);
            await _doctorRepository.SaveChanges();
        }

    }
}