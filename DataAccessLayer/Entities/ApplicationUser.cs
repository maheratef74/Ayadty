using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Entities;

public class ApplicationUser : IdentityUser
{
    public string? ProfilePhoto { get; set; } 
}