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

using System.Security.Claims;
using BusinessLogicLayer.Services.File;
using presentationLayer.Models.WorkingDays.ViewModel;


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
        private readonly IWorkingDaysService _workingDaysService;
        private readonly IFileService _fileService;
        public DoctorController(IDoctorService doctorService, IDoctorRepository doctorRepository,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IStringLocalizer<authController> localizer, IWorkingDaysService workingDaysService, IFileService fileService)
        {
            _doctorService = doctorService;
            _doctorRepository = doctorRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _localizer = localizer;
            _workingDaysService = workingDaysService;
            _fileService = fileService;
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

            ViewBag.WorkingDaysVMS= WorkingDaysVMS;
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
       
        [Authorize(Roles = "Doctor, Nurse , Patient" )]
        public async Task<IActionResult> Profile(string doctorId)
        {
            if (doctorId is null)
            { 
                doctorId= User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            // defult doctor to apear for user if need
            if (User.IsInRole(Roles.Patient))
            {
                doctorId = "3ab80e7d-95b1-4690-b97b-cebd8d4ed0bd";
            }
            // check if ID is not current user
            var DoctorDto = await _doctorService.GetDoctorById(doctorId);//return dto 
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
                doctor.IsDoctor = true;
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
        public async Task<IActionResult> Update(string doctorId)
        {
            var doctorDto = await _doctorService.GetDoctorById(doctorId);
            if (doctorDto == null)
            {
                return NotFound();
            }
            var updateDoctorVM = doctorDto.ToUpdateDoctorVM();
            return View(updateDoctorVM);
        }

        
         [HttpPost]
        public async Task<IActionResult> Update(UpdateDoctorVM updatedDoctor)
        {
           if (!ModelState.IsValid)
            {
                return View(updatedDoctor);
            }
            string uniqueFileName;
            if (updatedDoctor.FormFilePhoto != null && updatedDoctor.FormFilePhoto.Length > 0)
            {
                uniqueFileName = await _fileService.UploadFile(updatedDoctor.FormFilePhoto, "img");
            }
            else
            {
                uniqueFileName = updatedDoctor.ProfilePhoto;
            }
            var user = await _userManager.FindByIdAsync(updatedDoctor.DoctorId);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(updatedDoctor);
            }

            if (!string.IsNullOrEmpty(updatedDoctor.Password))
            {
                var removePasswordResult = await _userManager.RemovePasswordAsync(user);

                if (!removePasswordResult.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to remove old password.");
                    return View(updatedDoctor);
                }

                var addPasswordResult = await _userManager.AddPasswordAsync(user, updatedDoctor.Password);
                if (!addPasswordResult.Succeeded)
                {
                    foreach (var error in addPasswordResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(updatedDoctor);
                }
            }
            var doctortDto = updatedDoctor.ToUpdateDoctorDto();
            doctortDto.ProfilePhoto = uniqueFileName;
            await _doctorService.UpdateDoctor(doctortDto);
            return RedirectToAction("profile", "Doctor" , new {doctorId = updatedDoctor.DoctorId});
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
        [Authorize(Roles = Roles.Doctor)]
        public async Task<IActionResult> Delete(string doctorId)
        {
            await _doctorService.DeleteDoctor(doctorId);
            TempData["SuccessMessage"] = _localizer["Deleted successfully."].Value;
            return RedirectToAction("ShowAllStaf", "DashBoard");
        }

       
    }
}

