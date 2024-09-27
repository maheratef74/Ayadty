using BusinessLogicLayer.DTOs.Doctor;
using BusinessLogicLayer.DTOs.Prescription;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.Doctor;
using presentationLayer.Models.Doctor.ViewModel;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Doctor;
using Microsoft.AspNetCore.Identity;
using presentationLayer.Models.Appointment.ViewModel;

namespace presentationLayer.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IDoctorRepository _doctorRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DoctorController(IDoctorService doctorService, IDoctorRepository doctorRepository,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _doctorService = doctorService;
            _doctorRepository = doctorRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Edit_oppning_days()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit_oppning_days(PrescriptionDetailsDto prescriptionDetailsDto)
        {

































            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Profile(string DoctorId)
        {
            // check if ID is not current user
            var doctor = new Doctor()
            {
                FullName = "kareem",
                Price = 100,
                Phone = "01000097285",
                YearsOfExperience = 8,
                IsAvalibleToAppoinment = true,

                UserName = "Maher2"
                
            };
            IdentityResult result = await _userManager
                .CreateAsync(doctor, "123456");

            await _userManager.AddToRoleAsync(doctor, "Doctor");
            // Create a Cookie
            await _signInManager.SignInAsync(doctor, true);
            /*await _doctorRepository.Add(doctor);
            await _doctorRepository.SaveChange();*/
           /* var Doctor = await _doctorService.GetDoctorById("567860a7-fc3b-4f9c-b271-75877949a2c3");
            var doctorVM = Doctor.ToDoctorVM();*/
            return View();
        }
        [HttpGet]
        public IActionResult Update(string doctorId)
        { 
              return View();
        }
        public IActionResult AboutMe()
        { 
            return View();
        }
    }
}

