using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Clinic;
using DataAccessLayer.Entities;

using presentationLayer.Validation;

using BusinessLogicLayer.DTOs.Appointment;


namespace presentationLayer.Models.Clinic.ViewModel;



    public class UpdateClinicVM
    {
        public int ClinicId { get; set; }

        public string? Email { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }

        public string? ProfilePhoto { get; set; }
         
    public string location { get; set; }
    public string PhoneNumber { get; internal set; }

    public List<WorkDay> DaysOfWork { get; set; }

}



public static class UpdateClinicExtenionMethod
{
    public static UpdateClinicDto ToUpdateClinicDto(this UpdateClinicVM vm)
    {
        return new UpdateClinicDto
        {
            clinicId = vm.ClinicId,
            Name = vm.Name,
            Email = vm.Email,
            Location = vm.location,

            PhoneNumber = vm.Phone,

            ProfilePhoto = vm.ProfilePhoto,
            

        };

    }
    public static UpdateClinicVM ToUpdateClinicVM(this ClinicDetailsDto dto)
    {
        return new UpdateClinicVM
        {
            ClinicId = dto.clinicId,
            Name = dto.Name,
            Email = dto.Email,
            location = dto.Location,

            Phone = dto.PhoneNumber,

            ProfilePhoto = dto.ProfilePhoto,

        };
    }
}


/*
public static class ClinicExtensionMethold
{
    public static UpdateClinicVM ToClinicVm(this ClinicDetailsDto clinicDetailsDto)
    {
        return new UpdateClinicVM()
        {
            ClinicId = clinicDetailsDto.clinicId,
            Name = clinicDetailsDto.Name,
            Email = clinicDetailsDto.Email,
            location = clinicDetailsDto.Location,

            Phone = clinicDetailsDto.PhoneNumber,

            ProfilePhoto=clinicDetailsDto.ProfilePhoto,

           
        };
    }

    public static UpdateClinicDto ToClinicDto(this UpdateClinicVM updateclinicVm)
    {
        return new UpdateClinicDto()
        {
            
            Name = updateclinicVm.Name,
            Location= updateclinicVm.location,
            Email = updateclinicVm.Email,
            ProfilePhoto = updateclinicVm.ProfilePhoto,
            PhoneNumber = updateclinicVm.PhoneNumber,

            DaysOfWork = updateclinicVm.DaysOfWork,

              clinicId = updateclinicVm.ClinicId,


        };
    }
}
*/



