using Microsoft.AspNetCore.Identity;

namespace presentationLayer.Controllers;

public class RoleSeeder
{
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
  
    
    
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleSeeder(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task SeedRolesAsync()
    {
        string[] roleNames = { "Doctor", "Patient" , "Nurse" };

        foreach (var roleName in roleNames)
        {
           /* if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }*/
        }
    }
    
}