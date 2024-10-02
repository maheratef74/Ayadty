using BusinessLogicLayer.Services.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.DashBoard.ViewModel;

namespace presentationLayer.Controllers;

[Authorize(Roles = "Doctor,Nurse")]
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
    
    //[HttpPost]
    /*public async Task<IActionResult> CreateAppointment()
    {
        return View();
    }*/
   
}