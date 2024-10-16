using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using BusinessLogicLayer.Services.Notification;
using BusinessLogicLayer.Services.Patient;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.ApplicationUser;
using DataAccessLayer.Repositories.Doctor;
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
    private readonly IStringLocalizer<authController> _localizer;
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly INotificationService _notificationService;
    public authController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IPatientService patientService, 
       IStringLocalizer<authController> localizer , IApplicationUserRepository applicationUserRepository, INotificationService notificationService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _patientService = patientService;
        _localizer = localizer;
        _applicationUserRepository = applicationUserRepository;
        _notificationService = notificationService;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginAR loginAr)
    {
        if (ModelState.IsValid)
        {
            var user = await _applicationUserRepository.GetUserByPhoneNUmber(loginAr.Phone);
            if (user is not null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginAr.Password);

                if (isPasswordValid)
                {
                    // Create a Cookie
                    await _signInManager.SignInAsync(user, loginAr.RememberMe);
                    if (User.IsInRole(Roles.Patient))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("DailyAppointment", "DashBoard");
                }
            }
            ModelState.AddModelError("Password", _localizer["Username or Password invalid"]);
        } 
        return View(loginAr);
    }
    [HttpGet]
    public  IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public  async Task<IActionResult> Register(RegisterAR newPatient)
    {
        if (ModelState.IsValid)
        {
            var patientUser = newPatient.ToPatient();
            IdentityResult result = await _userManager
                .CreateAsync(patientUser, newPatient.Password);
            if (result.Succeeded) // User saved succesfully to database
            {
                await _userManager.AddToRoleAsync(patientUser, Roles.Patient);
                // Create a Cookie
                if(User.IsInRole(Roles.Doctor) || User.IsInRole(Roles.Nurse))
                {
                    TempData["successMessage"] = _localizer["Acount Created successfully"].Value;
                    return RedirectToAction("ShowAllPatients", "DashBoard");
                }
                await _signInManager.SignInAsync(patientUser , newPatient.RememberMe);
                TempData["successMessage"] = _localizer["Acount Created successfully"].Value;
                
                string message = $"تم انشاء حساب باسم {newPatient.Name}.";
          
                await _notificationService.CreateNotification(message);
                return RedirectToAction("Index", "Home");
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
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "auth");
    }
    
    public async Task<IActionResult> CheckPhone(string PhoneNumber, string? PatientId = null)
    {
        var user = await _applicationUserRepository.GetUserByPhoneAndExcludeCurrentPatient(PhoneNumber, PatientId);
        if (user is null) return Json(true);
    
        return Json(false);
    }

}