using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class ClinicController : Controller
    {
        public IActionResult Profile(string layout)
        {
            // Set the layout flag based on the query parameter
            ViewData["UseAlternateLayout"] = layout == "Layout";
        
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
