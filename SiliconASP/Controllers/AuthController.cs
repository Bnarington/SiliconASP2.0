using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiliconASP.ViewModels.Sections;
using Infrastructure.Services;

namespace SiliconASP.Controllers;

public class AuthController(UserService userService) : Controller
{

    private readonly UserService _userService = userService;



    [Route("/signup")]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup")]
    public async  Task<IActionResult> SignUp(SignUpViewModel model)
    { 
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(model.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                return RedirectToAction("Signin", "Auth");
        }
        return View(model);
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


