using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using BusinessLogicLayer.Services.Patient;
using DataAccessLayer.Repositories.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace presentationLayer.Validation;

public class UniquePhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var serviceProvider = validationContext.GetService<IServiceProvider>();
        /*var _PatientService = serviceProvider.GetService<IPatientService>();
        var _PatientRepository = serviceProvider.GetService<IPatientRepository>();*/
        var localizer = serviceProvider.GetService<IStringLocalizer<UniquePhoneNumberAttribute>>();
      
       var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
       var patient = dbContext.Users.Any(u => u.Phone == value.ToString());
      //  var patient = _PatientRepository?.GetPatientByPhoneNUmber(value.ToString());
     //  Console.WriteLine("Phone number being validated: " + value);
     //   Console.WriteLine("ID being validated: " + patient);
        if (patient)
        {
            var errorMessage = localizer["Use Another Phone Number" ] ?? "Phone number is already in use.";
            return new ValidationResult(errorMessage);
        }
        return ValidationResult.Success;
    }

    
}