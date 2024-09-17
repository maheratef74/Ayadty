using BusinessLogicLayer.Services.Appointment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Appointment.ViewModel;

namespace presentationLayer.Controllers;

public class AppointmentController : Controller
{
    private readonly IAppointmentService _appointmentService;
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    [HttpGet]
    public async Task<IActionResult> Creat()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult>  Creat(CreatAppointmentAR request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        await _appointmentService.CreatAppointment(request.ToDto());
        return RedirectToAction("DailyAppointment");
       
    }
    [HttpGet]
    public async Task<IActionResult> Details(int appointedId )
    {
        var appointment = await _appointmentService.GetAppointmentByID(appointedId);
        var appointmentVM = new GetAppointmentDetailsVM()
        {
            appointment = appointment
        };
        return View(appointmentVM);
    }
    [HttpGet]
    public IActionResult DailyAppointment()
    {
        return View();
    }
}