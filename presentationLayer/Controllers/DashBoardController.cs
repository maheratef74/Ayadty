using BusinessLogicLayer.Services.Appointment;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.DashBoard.ViewModel;

namespace presentationLayer.Controllers;

public class DashBoardController:Controller
{
    private readonly IAppointmentService _appointmentService;

    public DashBoardController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> DailyAppointment()
    {
        var appointments =  await _appointmentService.GetAllForDay(null);
        var getAllAppointmentVM = new GetAllAppointmentVM
        {
            appointments = appointments 
        };
        return View(getAllAppointmentVM);
    }
    public IActionResult AddPatient()
    {
        return View();
    }
    public IActionResult EditAppointment()
    {
        return View();
    }

}