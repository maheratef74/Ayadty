using BusinessLogicLayer.Services.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using DataAccessLayer.Entities;
using presentationLayer.Models.Doctor.ViewModel;

namespace presentationLayer.Controllers;

public class DoctorInfoViewComponent:ViewComponent
{
    private readonly IDoctorService _doctorService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DoctorInfoViewComponent(IDoctorService doctorService, IHttpContextAccessor httpContextAccessor)
    {
        _doctorService = doctorService;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
       var DoctorId =   _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
       
       var doctorDto = await _doctorService.GetDoctorById(DoctorId);
       var doctorVM = doctorDto.ToDoctorVM();
       return View(doctorVM);
    }
}