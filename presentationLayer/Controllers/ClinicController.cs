using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BusinessLogicLayer.Services.Clinic;
using BusinessLogicLayer.Services.Patient;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Clinic.ViewModel;
using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.File;
using presentationLayer.Models.Appointment.ViewModel;
using presentationLayer.Models.Patient.ViewModel;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace presentationLayer.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IClinicService _clinicService;
        private readonly IStringLocalizer<authController> _localizer;


        
        public ClinicController(IClinicService clinicService, IStringLocalizer<authController> localizer, IFileService fileService)
        {
            _clinicService = clinicService;
            _localizer = localizer;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            string id = "1";
            var clinicDto = await _clinicService.GetClinicById(id);
            var clinicVM = clinicDto.ToClinicVM();
            return View(clinicVM);
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var clinicId = "1";
            
            var clinic = await _clinicService.GetClinicById(clinicId);
            
            var updateclinicVM = clinic.ToUpdateClinicVM();

            return View(updateclinicVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateClinicVM updatedClinic)
        {
            if(!ModelState.IsValid)
            {
                return View(updatedClinic);
            }
            string uniqueFileName;
            if (updatedClinic.FormFilePhoto != null && updatedClinic.FormFilePhoto.Length > 0)
            {
                uniqueFileName = await _fileService.UploadFile(updatedClinic.FormFilePhoto, "img");
            }
            else
            {
                uniqueFileName = updatedClinic.ProfilePhoto;
            }
            var clinicDto = updatedClinic.ToUpdateClinicDto();
            await _clinicService.UpdateClinic(clinicDto);
            return RedirectToAction("Profile", "clinic");
        }
        
        [HttpGet]
        public async Task<IActionResult> ControllAppointment()
        {
            var ClinicIsOpen = new ClinicIsAvailable();
            ClinicIsOpen.IsOpen = await _clinicService.IsAvailbleToAppointment();
            return View(ClinicIsOpen);
        }

        public async Task<IActionResult> StopNewAppointments()
        {
            await _clinicService.StopNewAppointment();
            TempData["successMessage"] = _localizer["Appointments Stoped successfully"].Value;
            return RedirectToAction("ControllAppointment", "Clinic");
        }
        public async Task<IActionResult> OpenNewAppointments()
        {
            await _clinicService.OpenNewAppointments();
            TempData["successMessage"] = _localizer["Appointments Opened successfully"].Value;
            return RedirectToAction("ControllAppointment", "Clinic");
        }
    }
}