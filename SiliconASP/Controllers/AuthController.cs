using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SiliconASP.ViewModels.Sections;
using Infrastructure.Services;
using System.Security.Claims;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {

        if (ModelState.IsValid)
        {
            var result = await _userService.SignInUserAsync(model.Form);
            if (result!= null)
            {
                var userEntity = (UserEntity)result.ContentResult!;

                if ( userEntity != null)
                {
                    var claims = new List<Claim>
                    {
                    new(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                    new(ClaimTypes.Name, userEntity.Email),
                    new(ClaimTypes.Email, userEntity.Email)
                    };
                    await HttpContext.SignInAsync("AuthCookie", new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthCookie")));
                    return RedirectToAction("Details", "Account");
                }
            }
        }

        model.ErrorMessage = "Invalid Email or Password";
        return View(model);
    }

    public new async Task<IActionResult> SignOut()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("SignIn", "Auth");
    }
}


