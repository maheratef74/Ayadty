using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Ptient;

public class UpdatePatientDto
{
    public string PatientId { get; set; }

    public DateTime DateOfBirth { get; set; }
    public Enums.Gender Gender { get; set; }


    public string? Email { get; set; }

    public string Address { get; set; }
    public string password { get; set; }
    public string? FacebookProfile { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string ProfilePhoto { get; set; }
}
public static class UpdatePatientExtensionsDto
{
    public static Patient? ToUpdatePatient(this UpdatePatientDto dto)
    {
        if (dto == null)
        {
            return null;
        }

        var patient = new Patient()

        {
            Id = dto.PatientId,
            FullName = dto.FullName,
            Gender = dto.Gender,
            Phone = dto.Phone,
            Email = dto.Email,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            FacbookProfile = dto.FacebookProfile,
            ProfilePhoto = dto.ProfilePhoto
        };
        return patient;
    }
}