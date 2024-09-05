using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers;

public class AppoinmentController : Controller
{
    [HttpGet]
    public IActionResult Creat()
    {
        return View();
    }
}