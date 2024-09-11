using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers;

public class DashBoardController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult DailyAppointment()
    {
        return View();
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