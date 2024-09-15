using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers;

public class HomeController:Controller
{
    [HttpGet]
    public async Task<IActionResult> Home()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Error404()
    {
        return View();
    }
    
}