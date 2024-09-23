using System.Security.Claims;
using BusinessLogicLayer.Services.Patient;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.Appointment.CompositeViewModel;
using presentationLayer.Models.Patient.ViewModel;
namespace presentationLayer.Controllers;

public class HomeController:Controller
{
    private readonly IPatientService _patientService;

    public HomeController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if(User.IsInRole(Roles.Doctor) || User.IsInRole(Roles.Nurse))
        {
            return RedirectToAction("DailyAppointment", "DashBoard");
        }
        var user = await _patientService.GetPatientById(userId);
        var userPatient = user.ToPatientVM();
        var model = new AppointmentPageVM_AR
        {
            PatientVM = userPatient, // Show the patient details
            CreatAppointmentAR = new CreatAppointmentAR() // Prepare an empty form for the appointment
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Error404()
    {
        return View();
    }
    
}