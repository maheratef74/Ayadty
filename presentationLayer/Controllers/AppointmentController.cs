using System.Security.Claims;
using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Appointment.ViewModel;
using PresentationLayer.Models.Appointment.ViewModel;
using presentationLayer.Models.Patient.ViewModel;
namespace presentationLayer.Controllers;
using presentationLayer.Models.Appointment.CompositeViewModel;

[Authorize]
public class AppointmentController : Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    public AppointmentController(IAppointmentService appointmentService, IPatientService patientService)
    {
        _appointmentService = appointmentService;
        _patientService = patientService;
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _patientService.GetPatientById(userId);
        var userPatient = user.ToPatientVM();
        var model = new AppointmentPageVM_AR
        {
            PatientVM = userPatient, // Show the patient details
            CreatAppointmentAR = new CreatAppointmentAR() // Prepare an empty form for the appointment
        };
        model.CreatAppointmentAR.PatieentId = userId;
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult>  Create(AppointmentPageVM_AR request)
    {
        ModelState.Clear();
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        request.CreatAppointmentAR.PatieentId = userId;
        // Validate only the CreatAppointmentAR property
        var isValid = TryValidateModel(request.CreatAppointmentAR, nameof(request.CreatAppointmentAR));
        if (!isValid)
        {
            return View(request.CreatAppointmentAR);
        }

        var appointmentDto = request.CreatAppointmentAR.ToDto();
        await _appointmentService.CreatAppointment(appointmentDto);
        return RedirectToAction("DailyAppointment");
    }
    [HttpGet]
    public async Task<IActionResult> Details(string appointedId )
    {
        var isDoctor = User.IsInRole(Roles.Doctor);
        var isNurse = User.IsInRole(Roles.Nurse);
        var appointment = await _appointmentService.GetAppointmentByID(appointedId);
        var currentUsserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (appointment is null || (!isDoctor && !isNurse && currentUsserId != appointment.PatientId) )
        {
            return RedirectToAction("Error404", "Home");
        }
        var appointmentVM = new GetAppointmentDetailsVM()
        {
            appointment = appointment
        };
        return View(appointmentVM);
    }
    [HttpGet]
    public async Task<IActionResult> DailyAppointment()
    {
        var appointments = await _appointmentService.GetAllForDay(null);
        
        var getAllAppointmentVM = new SpecificDetailsAppointmentVM
        {
            Appointments = appointments.ToAppointmentspecificDetailsVms()
        };
        return View(getAllAppointmentVM);
    }

    [HttpGet]
    public async Task<IActionResult> Update(string appointedId)
    {
        var appointment = await _appointmentService.GetAppointmentByID(appointedId);
       
        return View(appointment.ToAppointmentVm());
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateAppointmentVM updtedAppointed)
    {
        var appointmentDto = updtedAppointed.ToAppointmentDto();
        _appointmentService.UpdateAppointment(appointmentDto);
        return RedirectToAction("Details", "Appointment" , new{appointedId = updtedAppointed.AppointmentId});
    }

}