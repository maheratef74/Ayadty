using BusinessLogicLayer.DTOs.Doctor;
using BusinessLogicLayer.DTOs.Prescription;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Doctor;
using presentationLayer.Models.Doctor.ViewModel;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Doctor;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Appointment.ViewModel;
using presentationLayer.Models.Auth.ActionRequest;
using presentationLayer.Models.Doctor.ActionRequest;
using System.Security.Claims;

namespace presentationLayer.Controllers
{
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
        public IActionResult Edit_oppning_days()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit_oppning_days(PrescriptionDetailsDto prescriptionDetailsDto)
        {
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var DoctorId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            // check if ID is not current user
            var DoctorDto = await _doctorService.GetDoctorById(DoctorId);//return dto 
            var DoctorVM = DoctorDto.ToDoctorVM();
            return View(DoctorVM);
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
                    await _signInManager.SignInAsync(doctor , doctorAr.RememberMe);
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
        public async Task<IActionResult> Update(string doctorId)
        {
            var doctor = await _doctorService.GetDoctorById(doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
            var updateDoctorVM = doctor.ToUpdateDoctorVM();
            return View(updateDoctorVM);
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateDoctorVM updatedDoctor)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedDoctor);
            }
            
            var doctorDto = updatedDoctor.ToUpdateDoctorDto();
            await _doctorService.UpdateDoctor(doctorDto);
            return RedirectToAction("Profile", "doctor", new {  DoctorId=updatedDoctor.DoctorId });
        }



        public IActionResult AboutMe()
        { 
            return View();
        }
    }
}

