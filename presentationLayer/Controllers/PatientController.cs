using System.Security.Claims;
using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using presentationLayer.Models.Appointment.CompositeViewModel;
using presentationLayer.Models.Patient.ViewModel;


namespace presentationLayer.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        public PatientController(IPatientService patientService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<IActionResult> Profile(string patientId)
        {
            // check if ID is not current user or not Nurse or doctor
            var isDoctor = User.IsInRole(Roles.Doctor);
            var isNurse = User.IsInRole(Roles.Nurse);

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!isDoctor && !isNurse && currentUserId != patientId)
            {
                return RedirectToAction("Error404", "Home");
            }

            var Patient = await _patientService.GetPatientById(patientId);
            var Appointments = await _appointmentService
                .GetAllAppointmentByPatientId(patientId);
            
            if (Patient is null)
            {
                return View();
            }

            var patientVM = Patient.ToPatientVM();
            var patientAndHisAppointments = new PatientVM__hisAppointments
            {
                PatientVm = patientVM,
                AppointmentsDetailsDto = Appointments
            };
            return View(patientAndHisAppointments);
        }
        
        [HttpGet]
        public async Task<IActionResult> Update(string patientId)
        {
            var patient = await _patientService.GetPatientById(patientId);
            if (patient == null)
            {
                return NotFound();
            }
            var updatePatientVM = patient.ToUpdatePatientVM();
            return View(updatePatientVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePatientVM updatedPatient)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedPatient);
            }
            var patientDto = updatedPatient.ToUpdatePatientDto();
            
             await _patientService.UpdatePatient(patientDto);

             return RedirectToAction("Profile", "Patient",
                new {patientId = updatedPatient.PatientId });
        }
    }
}
