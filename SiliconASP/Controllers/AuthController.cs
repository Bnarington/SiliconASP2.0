using Microsoft.AspNetCore.Mvc;
using SiliconASP.ViewModels.Sections;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Factories;

namespace SiliconASP.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{

    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [Route("/signup")]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Detalis", "Account");

        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup")]
    public async  Task<IActionResult> SignUp(SignUpViewModel model)
    { 
        if (ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == model.Form.Email);
            if (exists)
            {
                ModelState.AddModelError("Allready exists", "A user with this email adress allready exists.");
                ViewData["ErrorMessage"] = "A user with this email adress allready exists.";
                return View(model);
            }

            var userEntity = UserFactory.Create(model.Form);

            var result = await _userManager.CreateAsync(userEntity, model.Form.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Auth");
            }
        }
        return View(model);
    }

    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");

        return View();
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Form.Email, model.Form.Password, model.Form.RememberMe, false);
            if (result.Succeeded)
            {
                if(!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Details", "Account");
            }
            
        }

        ModelState.AddModelError("Incorrect values", "Incorrect email or password.");
        ViewData["ErrorMessage"] = "Incorrect email or password";
        return View();
    }

    [Route("/singout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}


//    if (ModelState.IsValid)
//    {
//        var result = await _userService.SignInUserAsync(model.Form);
//        if (result != null)
//        {
//            var userEntity = (UserEntity)result.ContentResult!;

//            if (userEntity != null)
//            {
//                var claims = new List<Claim>
//                {
//                new(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
//                new(ClaimTypes.Name, userEntity.Email),
//                new(ClaimTypes.Email, userEntity.Email)
//                };
//                await HttpContext.SignInAsync("AuthCookie", new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthCookie")));
//                return RedirectToAction("Details", "Account");
//            }
//        }
//    }

//    model.ErrorMessage = "Invalid Email or Password";
//    return View(model);
//}

//public new async Task<IActionResult> SignOut()
//{
//    await HttpContext.SignOutAsync();
//    return RedirectToAction("SignIn", "Auth");
//}