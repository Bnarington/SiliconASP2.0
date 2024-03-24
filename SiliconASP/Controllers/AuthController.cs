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
        return RedirectToAction("Auth", "Signin");
    }

    [Route("/signin")]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signin")]
    public IActionResult SignIn(SignInViewModel model)
    {

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        //var result = _authService.SignIn(model.Form)
        //if (result)
        //    return RedirectToAction("Auth", "SignIn");

        model.ErrorMessage = "Invalid Email or Password";
        return View(model);
    }
}


