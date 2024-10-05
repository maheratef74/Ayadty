using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class ClinicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
