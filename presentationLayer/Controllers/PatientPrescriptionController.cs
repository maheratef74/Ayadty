using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Controllers
{
    public class PatientPrescriptionController : Controller
    {
        public IActionResult take()
        {
            return View();
        }
    }
}
