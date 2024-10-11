using DataAccessLayer.Entities;
using System;

namespace BusinessLogicLayer.DTOs.Doctor
{
    public class UpdateDoctorDto
    {
        public string DoctorId { get; set; } // Primary Key
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
       
        public string? Email { get; set; }
        public string? ProfilePhoto { get; set; }
        public int? YearsOfExperience { get; set; }
        public int? Price { get; set; }
    }

    public static class UpdateDoctorExtensionsDto
    {
        public static DataAccessLayer.Entities.Doctor? ToUpdateDoctor(this UpdateDoctorDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            var doctor = new DataAccessLayer.Entities.Doctor()
            {
                Id = dto.DoctorId,
                FullName = dto.Name,
                Phone = dto.PhoneNumber,
                Email = dto.Email,
                ProfilePhoto = dto.ProfilePhoto,  
                YearsOfExperience = dto.YearsOfExperience,
                Price = dto.Price
            };
            return doctor;
        }
    }
}
