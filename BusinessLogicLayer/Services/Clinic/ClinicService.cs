
using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Clinic;
using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Clinic;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
namespace BusinessLogicLayer.Services.Clinic;

public class ClinicService : IClinicService
{
    private readonly string _uploadsPath;

    private readonly IClinicRepository _clinicRepository;
    private IClinicService _clinicServiceImplementation;

    public ClinicService(IClinicRepository clinicRepository)
    {
        _clinicRepository =  clinicRepository;

        _uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

        // تأكد من وجود المجلد
        if (!Directory.Exists(_uploadsPath))
        {
            Directory.CreateDirectory(_uploadsPath);
        }
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

        if (clinic is not null)
        {
            await _clinicRepository.Update(clinic);
            await _clinicRepository.SaveChanges();
        }
    }






    public async Task<string> SavePhotoPathAsync(IFormFile photo, string clinicId) // تغيير النوع إلى string
    {
        if (photo != null && photo.Length > 0)
        {
            // احصل على اسم الملف
            var fileName = Path.GetFileName(photo.FileName);
            var filePath = Path.Combine(_uploadsPath, fileName);

            // حفظ الصورة في السيرفر
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(stream);
            }

            // احصل على الكلينك وقم بتحديث مسار الصورة
            var clinic = await _clinicRepository.GetClinicByIdAsync(clinicId);
            if (clinic != null)
            {
                clinic.ProfilePhoto = $"/images/{fileName}"; // حفظ المسار النسبي
                await _clinicRepository.UpdateClinicAsync(clinic);
                return clinic.ProfilePhoto;
            }
        }
        throw new Exception("Invalid photo or clinic.");
    }


}