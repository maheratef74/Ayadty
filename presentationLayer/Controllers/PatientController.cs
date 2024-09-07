using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class PatientController : Controller
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
