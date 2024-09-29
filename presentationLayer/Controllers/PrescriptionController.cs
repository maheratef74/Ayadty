using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Patient;
using BusinessLogicLayer.Services.Prescription;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.Prescription.ActionRequest;

namespace presentationLayer.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IPatientService _patientService;
        public PrescriptionController(IPrescriptionService prescriptionService, IAppointmentService appointmentService, IPatientService patientService)
        {
            _prescriptionService = prescriptionService;
            _appointmentService = appointmentService;
            _patientService = patientService;
        }
        [HttpGet] 
        public async Task<IActionResult> Create(string AppointmentId)
        {
            var appointment = await _appointmentService.GetAppointmentByID(AppointmentId);
            var patient = await _patientService.GetPatientById(appointment.PatientId);
            CreatePrescrptionAR createPrescrptionAr = new CreatePrescrptionAR();
            
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

            await _prescriptionService.AddPrescription(request.ToPrescriptionDetailsDto());
            return View();
        }
        public IActionResult Show()
        {
            return View();
        }
    }
}
