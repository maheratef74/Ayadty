using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Services.Patient;

namespace presentationLayer.Validation;

public class UniquePhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var serviceProvider = validationContext.GetService<IServiceProvider>();
        var _PatientService = serviceProvider.GetService<IPatientService>();

        var patient = _PatientService?.GetPatientByPhoneNumber(value.ToString());
        
        if (patient is not null)
        {
            return new ValidationResult( "Phone Number Invalid");
        }

        return ValidationResult.Success;
    }

    
}