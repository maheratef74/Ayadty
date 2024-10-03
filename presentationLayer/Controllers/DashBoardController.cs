using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.DashBoard.ViewModel;
using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Controllers;

[Authorize(Roles = "Doctor,Nurse")]
public class DashBoardController:Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    public DashBoardController(IAppointmentService appointmentService, IPatientService patientService)
    {
        _appointmentService = appointmentService;
        _patientService = patientService;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> DailyAppointment(DateTime? date = null)
    {
     
        var selectedDate = date ?? DateTime.Today;

        var appointments = await _appointmentService.GetAllForDay(selectedDate);
        var getAllAppointmentVM = new GetAllAppointmentVM
        {
            appointments = appointments,
            SelectedDate = selectedDate
        };

        return View(getAllAppointmentVM);
    }
    [HttpGet]
    public async Task<IActionResult> CreateAppointment()
    {
        var patientsDto = await _patientService.GetAllPatients();
        var patientsVM = new List<PatientVM>();
        foreach (var patientDto in patientsDto)
        {
            var patientVM = patientDto.ToPatientVM();
            patientsVM.Add(patientVM);
        }
        
        var NurseAppointmentVM = new NurseAppointmentVM()
        {
            Patients = patientsVM
        };
        return View(NurseAppointmentVM);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAppointment(NurseAppointmentVM nurseAppointmentVm)
    {
        return View();
    }
   
    [HttpGet]
    public async Task<IActionResult> SearchPatients(string searchTerm)
    {
        var patientsDto = await _patientService.GetPatientsByName(searchTerm);
        var patientsVM = new List<PatientVM>();
        foreach (var patientDto in patientsDto)
        {
            var patientVM = patientDto.ToPatientVM();
            patientsVM.Add(patientVM);
        }
        return Json(patientsVM);
    }
}