using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using BusinessLogicLayer.Services.Patient;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentationLayer.Models;
using presentationLayer.Models.Auth.ActionRequest;
using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Controllers;

public class authController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IPatientService _patientService;
    private readonly IPatientRepository _patientRepository;
    private readonly IStringLocalizer<authController> _localizer;
    public authController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IPatientService patientService, IPatientRepository patientRepository, IStringLocalizer<authController> localizer)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _patientService = patientService;
        _patientRepository = patientRepository;
        _localizer = localizer;
    }
    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginAR loginAr)
    {
        if (ModelState.IsValid)
        {
            var user = await _patientRepository.GetPatientByPhoneNUmber(loginAr.Phone);
            if (user is not null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginAr.Password);

                if (isPasswordValid)
                {
                    // Create a Cookie
                    await _signInManager.SignInAsync(user, loginAr.RememberMe);
                    return RedirectToAction("Home", "Home");
                }
            }
            ModelState.AddModelError("Password", _localizer["Username or Password invalid"]);
        }

        return View(loginAr);
    }
    [HttpGet]
    public  async Task<IActionResult> Register()
    {
        return View();
    }
    [HttpPost]
    public  async Task<IActionResult> Register(RegisterAR newPatient)
    {
        if(!CheckPhone(newPatient.PhoneNumber)) 
            ModelState.AddModelError("PhoneNumber" , _localizer["Use Another Phone Number" ]); 
        
        if (ModelState.IsValid)
        {
            IdentityResult result = await _userManager
                .CreateAsync(newPatient.ToPatient(), newPatient.Password);
            if (result.Succeeded) // User saved succesfully to database
            {
                await _userManager.AddToRoleAsync(newPatient.ToPatient(), "Patient");
                // Create a Cookie
                await _signInManager.SignInAsync(newPatient.ToPatient(), newPatient.RememberMe);
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
    private bool CheckPhone(string phone)
    {
        var patient =  _patientService.GetPatientByPhoneNumber(phone);
        if (patient is null) return true;
        
        return false;
    }
}