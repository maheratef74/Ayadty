using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class ClinicController : Controller
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
