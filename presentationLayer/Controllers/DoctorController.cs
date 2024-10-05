using BusinessLogicLayer.DTOs.Doctor;
using BusinessLogicLayer.DTOs.Prescription;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Doctor;
using presentationLayer.Models.Doctor.ViewModel;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Appointment.ViewModel;
using presentationLayer.Models.Auth.ActionRequest;
using presentationLayer.Models.Doctor.ActionRequest;

namespace presentationLayer.Controllers
{
    //[Authorize(Roles = "Doctor")]

    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDoctorRepository _doctorRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStringLocalizer<authController> _localizer;

        public DoctorController(IDoctorService doctorService, IDoctorRepository doctorRepository,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IStringLocalizer<authController> localizer)
        {
            _doctorService = doctorService;
            _doctorRepository = doctorRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _localizer = localizer;
        }

        [HttpGet]
        [Authorize(Roles = "Doctor, Nurse")]
        public IActionResult Edit_oppning_days()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Doctor, Nurse")]
        public IActionResult Edit_oppning_days(PrescriptionDetailsDto prescriptionDetailsDto)
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Doctor, Nurse , Patient" )]
        public async Task<IActionResult> Profile(string DoctorId)
        {
            // check if ID is not current user
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddDoctorAR doctorAr)
        {
            if (ModelState.IsValid)
            {
                var doctor = doctorAr.ToDoctor();
                IdentityResult result = await _userManager
                    .CreateAsync(doctor, doctorAr.Password);
                if (result.Succeeded) 
                {
                    await _userManager.AddToRoleAsync(doctor, Roles.Doctor);
                    // Create a Cookie
                    // //   await _signInManager.SignInAsync(doctor , doctorAr.RememberMe);
                    TempData["successMessage"] = _localizer["Doctor Added successfully"].Value;
                    return RedirectToAction("DailyAppointment", "DashBoard");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View(doctorAr);
        }
        [HttpGet]
        public IActionResult Update(string doctorId)
        { 
              return View();
        }
        
        [Authorize(Roles = "Doctor, Nurse , Patient" )]
        public IActionResult AboutMe()
        { 
            return View();
        }
    }
}

