using System.ComponentModel.DataAnnotations;
using DataAccessLayer.DbContext;
using Microsoft.Extensions.Localization;

public class UniquePhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var serviceProvider = validationContext.GetService<IServiceProvider>();
        var dbContext = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
        var localizer = serviceProvider.GetService<IStringLocalizer<UniquePhoneNumberAttribute>>();
        var currentPatientIdProperty = validationContext.ObjectType.GetProperty("PatientId");
        var currentPatientId = currentPatientIdProperty?.GetValue(validationContext.ObjectInstance)?.ToString();

        var phoneNumber = value?.ToString();

        // Check if the phone number exists for a different user
        var existingUser = dbContext.Users
            .FirstOrDefault(u => u.Phone == phoneNumber && u.Id != currentPatientId);  // Exclude the current patient's ID

        if (existingUser is not null)
        {
            var errorMessage = localizer["Use Another Phone Number" ] ?? "Phone number is already in use.";
            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }
}