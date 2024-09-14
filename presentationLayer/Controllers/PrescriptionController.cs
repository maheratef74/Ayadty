using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class PrescriptionController : Controller
    {
        public IActionResult Creat()
        {
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
    }
}
