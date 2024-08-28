using System.Diagnostics;
using Ayadty.Models;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models;

namespace presentationLayer.Controllers;

public class authController : Controller
{
    private readonly ILogger<authController> _logger;

    public authController(ILogger<authController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
     [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
            if (model.UserType == Enums.UserType.Doctor)
            {
                // Map RegisterViewModel to Doctor entity
                var doctor = new Doctor
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                 //   Specialization = model.Specialization,
                    YearsOfExperience = model.YearsOfExperience ?? 0,
                    Price = model.Price,
                        
                };

                // Save doctor to database
                // Your code to save the doctor entity
            }
            else if (model.UserType == Enums.UserType.Patient)
            {
                // Map RegisterViewModel to Patient entity
                var patient = new Patient
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Address = model.Address
                };

                // Save patient to database
                // Your code to save the patient entity
            }

            // Redirect or return a success message
            return RedirectToAction("", "");

    }

    public IActionResult Login()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}