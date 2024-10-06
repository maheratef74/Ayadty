using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BusinessLogicLayer.Services.Clinic;
using BusinessLogicLayer.Services.Patient;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Clinic.ViewModel;
using BusinessLogicLayer.Services.Appointment;
using presentationLayer.Models.Appointment.ViewModel;
using presentationLayer.Models.Patient.ViewModel;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace presentationLayer.Controllers
{
    public class ClinicController : Controller
    {

        private readonly IClinicService _clinicService;
        private readonly IStringLocalizer<authController> _localizer;

        public ClinicController(IClinicService clinicService, IStringLocalizer<authController> localizer)
        {
            _clinicService = clinicService;
            _localizer = localizer;
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
        public async Task<IActionResult> Update(string clinicId)
        {
            clinicId = "1";
            var clinic = await _clinicService.GetClinicById(clinicId);
            if (clinic == null)
            {
                return NotFound();
            }

            var updateclinicVM = clinic.ToUpdateClinicVM();

            return View(updateclinicVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateClinicVM updatedClinic)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedClinic);
            }

            var clinicDto = updatedClinic.ToUpdateClinicDto();
            await _clinicService.UpdateClinic(clinicDto);
            return RedirectToAction("Profile", "clinic",
                new { clinicID = "1"});
        }
    }
}