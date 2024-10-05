using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services.WorkingDays;
using presentationLayer.Models.WorkingDays.ViewModel;

namespace presentationLayer.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IWorkingDaysService _workingDaysService;
        public IActionResult Profile(string layout)
        {
        
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
      
    }
}
