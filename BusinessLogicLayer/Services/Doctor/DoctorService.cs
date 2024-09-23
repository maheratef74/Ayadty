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
}