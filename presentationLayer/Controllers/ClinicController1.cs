using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class ClinicController1 : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
