using BusinessLogicLayer.DTOs.Doctor;
using BusinessLogicLayer.DTOs.Prescription;
using BusinessLogicLayer.DTOs.WorkingDayes;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Doctor;
using BusinessLogicLayer.Services.WorkingDays;
using presentationLayer.Models.Doctor.ViewModel;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Appointment.ViewModel;
using presentationLayer.Models.Auth.ActionRequest;
using presentationLayer.Models.Doctor.ActionRequest;
using presentationLayer.Models.WorkingDays.ViewModel;

namespace presentationLayer.Controllers
{

    [Authorize(Roles = "Doctor")]

    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDoctorRepository _doctorRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStringLocalizer<authController> _localizer;
        private readonly IWorkingDaysService _workingDaysService;
        public DoctorController(IDoctorService doctorService, IDoctorRepository doctorRepository,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IStringLocalizer<authController> localizer, IWorkingDaysService workingDaysService)
        {
            _doctorService = doctorService;
            _doctorRepository = doctorRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _localizer = localizer;
            _workingDaysService = workingDaysService;
        }

        [HttpGet]
        [Authorize(Roles = "Doctor, Nurse")]
        public async Task<IActionResult> UpdateWorkingDays()
        {
            var WorkingDaysDtos = await _workingDaysService.GetAllWorkingDays();

            var WorkingDaysVMS = new List<WorkingDaysVM>();
            foreach (var dayDto in WorkingDaysDtos)
            {
                var dayVM = dayDto.ToWorkingDayVm();
                WorkingDaysVMS.Add(dayVM);
            }
            return View(WorkingDaysVMS);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor, Nurse")]
        public async Task<IActionResult> UpdateWorkingDays(List<WorkingDaysVM> workingDaysVms)
        {
            var WorkingDaysDtos = new List<WorkingDayDto>();
            foreach (var dayVM in workingDaysVms)
            {
                var dayDto = dayVM.ToWorkingDayDto();
                WorkingDaysDtos.Add(dayDto);
            }

            await _workingDaysService.AddWorkingDays(WorkingDaysDtos);
            TempData["successMessage"] = _localizer["Working Days updated successfully"].Value;
            return RedirectToAction("UpdateWorkingDays", "Doctor");
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
        
        [HttpGet]
        [Authorize(Roles = Roles.Doctor )]
        public async Task<IActionResult> AddNurse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNurse(AddDoctorAR NurseAR)
        {
            if (ModelState.IsValid)
            {
                var nurse = NurseAR.ToDoctor();
                IdentityResult result = await _userManager
                    .CreateAsync(nurse, NurseAR.Password);
                if (result.Succeeded) 
                {
                    await _userManager.AddToRoleAsync(nurse, Roles.Nurse);
                    // Create a Cookie
                    // //   await _signInManager.SignInAsync(doctor , doctorAr.RememberMe);
                    TempData["successMessage"] = _localizer["Nurse Added successfully"].Value;
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
            return View(NurseAR);
        }
    }
}

