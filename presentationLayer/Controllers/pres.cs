using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class pres : Controller
    {
        public IActionResult Pres()
        {
            return View();
        }
    }
}
