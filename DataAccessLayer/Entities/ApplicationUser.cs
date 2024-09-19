using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string? ProfilePhoto { get; set; } 
}