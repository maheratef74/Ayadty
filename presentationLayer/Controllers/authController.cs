using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using BusinessLogicLayer.Services.Patient;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentationLayer.Models;
using presentationLayer.Models.Auth.ActionRequest;

namespace presentationLayer.Controllers;

public class authController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IPatientService _patientService;
    public authController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IPatientService patientService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _patientService = patientService;
    }
    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }
    [HttpGet]
    public  async Task<IActionResult> Register()
    {
        return View();
    }
    [HttpPost]
    public  async Task<IActionResult> Register(RegisterAR newPatient)
    {
        if (ModelState.IsValid)
        {
            var patient = new Patient()
            {
                FullName = newPatient.Name,
                Phone = newPatient.PhoneNumber,
                Address = newPatient.Address,
                Gender = newPatient.Gender,
              //  PasswordHash = newPatient.Password,
                DateOfBirth = newPatient.DateOfBirth,
                UserName = Guid.NewGuid().ToString()  // because it take alotof time to handel it but it's not handel 
            };
            IdentityResult result = await _userManager.CreateAsync(patient, newPatient.Password);
            if (result.Succeeded) // User saved succesfully to database
            {
                await _userManager.AddToRoleAsync(patient, "Patient");
                // Create a Cookie
                await _signInManager.SignInAsync(patient, newPatient.RememberMe);
                return RedirectToAction("Home", "Home");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
        }
        return View(newPatient);
    }
    public async Task<IActionResult> CheckPhone(string phone)
    {
        var patient = await _patientService.GetPatientByPhoneNumber(phone);
        if (patient is null)
        {
            return Json(true);
        }
        return Json(false);
    }
}