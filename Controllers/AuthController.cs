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
        if (!model.SignUpForm.TermsAndConditions)
        {
            ModelState.AddModelError("SignUpForm.TermsAndConditions", "You must agree to the Terms and Conditions.");
        }
        
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        return RedirectToAction("Index", "Home");
    }
}


