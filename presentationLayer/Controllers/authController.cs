using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using BusinessLogicLayer.Services.Prescription;
using presentationLayer.Models;
using presentationLayer.Models.Patient.ActionRequst;
using presentationLayer.Models.Prescription.ActionRequest;
using BusinessLogicLayer.Services.Patient;
using System.Runtime.InteropServices;
using BusinessLogicLayer.DTOs.Patient;
using BusinessLogicLayer.Services.Appointment;

namespace presentationLayer.Controllers;

public class authController : Controller
{
    private readonly IPatientService _patientService;
    public authController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddPatient(PatientAR request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }
     var patientDto = request.toDto();
     await _patientService.AddPatient(patientDto);
     return View();


    }

}