using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class DoctorController : Controller
    {

        public IActionResult Edit_oppning_days()
        {
            return View();
        }
    }
}
