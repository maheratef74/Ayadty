using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Update()

    }
}
