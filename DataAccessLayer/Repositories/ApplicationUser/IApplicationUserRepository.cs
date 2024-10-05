namespace DataAccessLayer.Repositories.ApplicationUser;
using DataAccessLayer.Entities;
public interface IApplicationUserRepository
{
    Task<ApplicationUser?> GetUserByPhoneNUmber(string PhoneNumber);
    Task<ApplicationUser?> GetUserByPhoneAndExcludeCurrentPatient(string phone, string? patientId = null);
}