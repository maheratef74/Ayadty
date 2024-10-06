using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Patient;
using BusinessLogicLayer.Services.Prescription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Prescription.ActionRequest;

namespace presentationLayer.Controllers
{
 //   [Authorize("Doctor")]
    public class PrescriptionController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IPatientService _patientService;
        private readonly IStringLocalizer<authController> _localizer;

        public PrescriptionController(IPrescriptionService prescriptionService, IAppointmentService appointmentService, IPatientService patientService, IStringLocalizer<authController> localizer)
        {
            _prescriptionService = prescriptionService;
            _appointmentService = appointmentService;
            _patientService = patientService;
            _localizer = localizer;
        }
        [HttpGet] 
        public async Task<IActionResult> Create(string AppointmentId)
        {
            var appointment = await _appointmentService.GetAppointmentByID(AppointmentId);
            var patient = await _patientService.GetPatientById(appointment.PatientId);
            CreatePrescrptionAR createPrescrptionAr = new CreatePrescrptionAR();
            
            createPrescrptionAr.PatientId = patient.PatientId;
            createPrescrptionAr.PatientName = appointment.PatientName;
            createPrescrptionAr.AppointmentId = appointment.AppointmentId;
            var dateOfBirth = patient.DateOfBirth;

            var today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) 
            {
                age--;
            }
            createPrescrptionAr.patientAge = age;
            createPrescrptionAr.Date = DateTime.Now;
            return View(createPrescrptionAr);
        }
         [HttpPost] 
         public async Task<IActionResult> Create(CreatePrescrptionAR request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var prescriptionDto = request.ToPrescriptionDetailsDto();
            var prescription = await _prescriptionService.AddPrescription(prescriptionDto);
            TempData["successMessage"] = _localizer["Prescription Created successfully"].Value;
            
            return RedirectToAction("Show" , "Prescription" , 
                new {PrescriptionId = prescription.PrescriptionId});
        }
        [HttpGet]
        public async Task<IActionResult>  Show(string PrescriptionId)
        {
            var prescriptionDto = await _prescriptionService.GetPrescriptionById(PrescriptionId);
            // does not convert to View Model because it same 
            return View(prescriptionDto);
        }
        [HttpGet]
        public async Task<IActionResult>  Update(string PrescriptionId)
        {
            var prescriptionDto = await _prescriptionService.GetPrescriptionById(PrescriptionId);

            var prescriptionAR = prescriptionDto.ToPrescriptionDetailsAR();
            return View(prescriptionAR);
        }
        [HttpPost]
        public async Task<IActionResult>  Update(UpdatePrescriptionAR updatedPrescriptionAr)
        {
            var prescriptionDto = updatedPrescriptionAr.ToPrescriptionDetailsDto();
            await _prescriptionService.UpdatePrescription(prescriptionDto);
            TempData["successMessage"] = _localizer["Prescription Updated successfully"].Value;
            return RedirectToAction("Show" , "Prescription" , 
                new {PrescriptionId = prescriptionDto.PrescriptionId});
        }
    }
}
