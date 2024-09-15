using BusinessLogicLayer.Services.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Profile(int patientId)
        {
            // check if ID is not current user
            var Patient = await _patientService.GetPatientById(patientId);
            var patientVM = Patient.ToPatientVM();  
            return View(patientVM);
        }
        public IActionResult Update()
        {
            return View();

        }
    }
}
