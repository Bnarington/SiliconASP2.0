using Microsoft.AspNetCore.Mvc;
using SiliconASP.ViewModels.Sections;

namespace SiliconASP.Controllers;

public class AuthController : Controller
{
    [Route("/signup")]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup")]
    public IActionResult SignUp(SignUpViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        return RedirectToAction("Index", "Home");
    }
}


