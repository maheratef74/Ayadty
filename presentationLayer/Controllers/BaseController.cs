using System.Diagnostics;
using Ayadty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using presentationLayer.Models;
namespace presentationLayer.Controllers;

public class BaseController : Controller
{
    private readonly ILogger<BaseController> _logger;
    private readonly IStringLocalizer<BaseController> _localizer;
    public BaseController(ILogger<BaseController> logger, IStringLocalizer<BaseController> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }
   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}