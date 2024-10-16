using BusinessLogicLayer.DTOs.HelperClass;
using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Patient;
using DataAccessLayer.Repositories.Doctor;
using DataAccessLayer.Repositories.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.DashBoard.ViewModel;
using presentationLayer.Models.Doctor.ViewModel;
using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Controllers;

[Authorize(Roles = "Doctor,Nurse")]
public class DashBoardController:Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IPatientService _patientService;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IStringLocalizer<authController> _localizer;
    public DashBoardController(IAppointmentService appointmentService, IPatientService patientService, IStringLocalizer<authController> localizer, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
    {
        _appointmentService = appointmentService;
        _patientService = patientService;
        _localizer = localizer;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
    }

    public IActionResult Index()
    {
        var appointments = new {
            Canceled = 10,
            Completed = 40,
            Pending = 15
        };

        return View(appointments);
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
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAppointment(NurseAppointmentVM nurseAppointmentVm)
    {
        var appointmentDto = nurseAppointmentVm.ToAppointmentDto();
        await _appointmentService.CreatAppointment(appointmentDto);
        TempData["successMessage"] = _localizer["Appointment Created successfully"].Value;
        return RedirectToAction("DailyAppointment" , "DashBoard");
    }
   
    [HttpGet]
    public async Task<IActionResult> SearchPatients(string query)
    {
        var patientsDtos = await _patientService.GetPatientsByName(query);
        var patientsVMS = new List<PatientVM>();
        foreach (var patientDto in patientsDtos)
        {
            var patientVM = patientDto.ToPatientVM();
            patientsVMS.Add(patientVM);
        }
        return PartialView("_SearchResults", patientsVMS);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllPatients(int pageNumber = 1, int pageSize = 10)
    {
        var patientsPaginatedList = await _patientRepository.GetAllPatients(pageNumber, pageSize);
        return View(patientsPaginatedList);
    }
    [HttpGet]
    public async Task<IActionResult> ShowAllStaf(int pageNumber = 1, int pageSize = 10)
    {
        var StafPaginatedList = await _doctorRepository.GetAllStaf(pageNumber, pageSize);
  
        
        return View(StafPaginatedList);
    }
}