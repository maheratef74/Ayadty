using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class ClinicController : Controller
    {
        public IActionResult Profile(string layout)
        {
        
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
