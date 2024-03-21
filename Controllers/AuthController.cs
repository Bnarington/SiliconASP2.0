using Microsoft.AspNetCore.Mvc;

namespace SiliconASP.Controllers;

public class AuthController : Controller
{
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }
}