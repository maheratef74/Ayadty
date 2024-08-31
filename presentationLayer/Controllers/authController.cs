using System.Diagnostics;
using Ayadty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentationLayer.Models;
namespace presentationLayer.Controllers;

public class authController : Controller
{
    private readonly ILogger<authController> _logger;
    private readonly IStringLocalizer<authController> _localizer;
    public authController(ILogger<authController> logger, IStringLocalizer<authController> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
      
            // Add your authentication logic here.
            // Example: Check user credentials and sign in.
            bool isAuthenticated = /* Your authentication logic */ false;

            if (isAuthenticated)
            {
                // Redirect to the desired page after successful login.
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            
        // If we got this far, something failed; redisplay the form.
        return View(model);
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
     [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
                var patient = new Patient
                {
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                   // Gender = model.Gender,
                    Address = model.Address
                };

                // Save patient to database
                //  code to save the patient entity
           

            // Redirect or return a success message
            return RedirectToAction("", "");

    }

  

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}