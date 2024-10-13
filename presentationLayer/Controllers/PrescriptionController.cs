using BusinessLogicLayer.Services.Appointment;
using BusinessLogicLayer.Services.Clinic;
using BusinessLogicLayer.Services.Patient;
using BusinessLogicLayer.Services.Prescription;
using BusinessLogicLayer.Services.WorkingDays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Localization;
using presentationLayer.Models.Prescription.ActionRequest;
using presentationLayer.Models.Prescription.ViewModel;

namespace presentationLayer.Controllers
{
   // [Authorize(Roles = Roles.Doctor)]
    public class PrescriptionController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly IPatientService _patientService;
        private readonly IStringLocalizer<authController> _localizer;
        private readonly IWorkingDaysService _workingDaysService;
        private readonly IClinicService _clinicService;
        public PrescriptionController(IPrescriptionService prescriptionService, IAppointmentService appointmentService, IPatientService patientService, IStringLocalizer<authController> localizer, IWorkingDaysService workingDaysService, IClinicService clinicService)
        {
            _prescriptionService = prescriptionService;
            _appointmentService = appointmentService;
            _patientService = patientService;
            _localizer = localizer;
            _workingDaysService = workingDaysService;
            _clinicService = clinicService;
        }
        [HttpGet] 
        [Authorize(Roles = Roles.Doctor)]
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
         [Authorize(Roles = Roles.Doctor)]
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
            
            var workingDaysDto = await _workingDaysService.GetAllWorkingDays();
            var clinicInfo = await _clinicService.GetClinicById("1");
            var prescriptionVM = prescriptionDto.ToPrescriptionsVm();
            
            prescriptionVM.clinicAdress = clinicInfo.Location;
            prescriptionVM.clinicPhone = clinicInfo.PhoneNumber;
            List<string> workingDays = new List<string>();
            foreach (var day in workingDaysDto)
            {
                workingDays.Add(day.DayOfWeek.ToString());
            }

            prescriptionVM.DaysOfWork = workingDays;
            // does not convert to View Model because it same 
            return View(prescriptionVM);
        }
        [HttpGet]
        [Authorize(Roles = Roles.Doctor)]
        public async Task<IActionResult>  Update(string PrescriptionId)
        {
            var prescriptionDto = await _prescriptionService.GetPrescriptionById(PrescriptionId);

            var prescriptionAR = prescriptionDto.ToPrescriptionDetailsAR();
            return View(prescriptionAR);
        }
        [HttpPost]
        [Authorize(Roles = Roles.Doctor)]
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
