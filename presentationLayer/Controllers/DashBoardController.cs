using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers;

public class DashBoardController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
}