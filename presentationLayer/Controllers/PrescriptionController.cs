using BusinessLogicLayer.Services.Prescription;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.Prescription.ActionRequest;

namespace presentationLayer.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }
        [HttpGet] 
        public async Task<IActionResult> Create()
        {
            return View();
        }
         [HttpPost] 
         public async Task<IActionResult> Create(CreatePrescrptionAR request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _prescriptionService.AddPrescription(request.ToPrescriptionDetailsDto());
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
    }
}
