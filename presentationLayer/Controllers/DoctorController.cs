using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class DoctorController : Controller
    {
        
        [HttpGet]
        public IActionResult Edit_oppning_days()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult profile()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            return View();
        }

    }
}
