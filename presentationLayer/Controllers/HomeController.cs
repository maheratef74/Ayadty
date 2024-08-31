using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers;

public class HomeController:Controller
{
    [HttpGet]
    public IActionResult Home()
    {
        return View();
    }
}