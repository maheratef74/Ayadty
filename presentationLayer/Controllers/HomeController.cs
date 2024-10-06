using System.Security.Claims;
using BusinessLogicLayer.Services.Patient;
using BusinessLogicLayer.Services.WorkingDays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.Appointment.CompositeViewModel;
using presentationLayer.Models.Patient.ViewModel;
using presentationLayer.Models.WorkingDays.ViewModel;

namespace presentationLayer.Controllers;
[Authorize]
public class HomeController:Controller
{
    private readonly IPatientService _patientService;
    private readonly IWorkingDaysService _workingDaysService;
    public HomeController(IPatientService patientService, IWorkingDaysService workingDaysService)
    {
        _patientService = patientService;
        _workingDaysService = workingDaysService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var WorkingDaysDtos = await _workingDaysService.GetAllWorkingDays();

        var WorkingDaysVMS = new List<WorkingDaysVM>();
        foreach (var dayDto in WorkingDaysDtos)
        {
            var dayVM = dayDto.ToWorkingDayVm();
            WorkingDaysVMS.Add(dayVM);
        }

        var model = new AppointmentPageVM_AR();
         model.WorkingDaysVms = WorkingDaysVMS;
        if (User.IsInRole(Roles.Doctor) || User.IsInRole(Roles.Nurse))
        {
            return View(model);
        }
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _patientService.GetPatientById(userId);
        var userPatient = user.ToPatientVM();
        model.PatientVM = userPatient;
        model.CreatAppointmentAR = new CreatAppointmentAR();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Error404()
    {
        return View();
    }
}