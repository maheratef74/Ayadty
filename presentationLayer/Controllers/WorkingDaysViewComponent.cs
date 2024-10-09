using BusinessLogicLayer.Services.WorkingDays;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Models.WorkingDays.ViewModel;

namespace presentationLayer.Controllers;

public class WorkingDaysViewComponent:ViewComponent
{
    private readonly IWorkingDaysService _workingDaysService;

    public WorkingDaysViewComponent(IWorkingDaysService workingDaysService)
    {
        _workingDaysService = workingDaysService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var workingDaysDtos = await _workingDaysService.GetAllWorkingDays();

        var workingDaysVMS = new List<WorkingDaysVM>();
        foreach (var dayDto in workingDaysDtos)
        {
            var dayVM = dayDto.ToWorkingDayVm();
            workingDaysVMS.Add(dayVM);
        }

        return View(workingDaysVMS); // Pass the data to the view component's view
    }
}