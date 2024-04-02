using Microsoft.AspNetCore.Mvc;


namespace SiliconASP.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
