using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Services.Patient;
using Microsoft.Extensions.Localization;

namespace presentationLayer.Validation;

public class UniquePhoneNumberAttribute : ValidationAttribute
{
    private readonly IStringLocalizer _localizer;

    public UniquePhoneNumberAttribute(IStringLocalizer localizer)
    {
        _localizer = localizer;
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var serviceProvider = validationContext.GetService<IServiceProvider>();
        var _PatientService = serviceProvider.GetService<IPatientService>();

        var patient = _PatientService?.GetPatientByPhoneNumber(value.ToString());
        
        if (patient is not null)
        {
            return new ValidationResult( _localizer["PhoneNumberInvalid"]);
        }

        return ValidationResult.Success;
    }

    
}