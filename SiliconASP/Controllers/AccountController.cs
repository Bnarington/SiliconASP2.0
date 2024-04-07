using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconASP.ViewModels.Sections;

namespace SiliconASP.Controllers;
public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressService addressService) : Controller
{

    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AddressService _addressService = addressService;

    [Route("/account")]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Auth");

    
        var userEntity = await _userManager.GetUserAsync(User);

        if (userEntity != null)
        {
            var viewModel = new AccountDetailsViewModel()
            {
                User = userEntity!
            };

            return View(viewModel);
        }
 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
    {
        var user = await _userManager.FindByEmailAsync(viewModel.User.Email!);
        if (user != null)
        {
            user.FirstName = viewModel.User.FirstName;
            user.LastName = viewModel.User.LastName;
            user.PhoneNumber = viewModel.User.PhoneNumber;
            user.Bio = viewModel.User.Bio;
        }

        var result = await _userManager.UpdateAsync(user!);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("Update failed", "Unable to update user.");
            ViewData["ErrorMessage"] = "Unable to update user.";
        }

        return RedirectToAction("Details", "Account", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddressInfo(AccountDetailsViewModel viewModel)
    {
        var addressResult = await _addressService.GetOrCreateAddressAsync(viewModel.AddressInfo.AddressLine_1, viewModel.AddressInfo.PostalCode, viewModel.AddressInfo.City);

        if (addressResult.MyStatusCode != MyStatusCode.OK)
        {
            ModelState.AddModelError("Update failed", "Unable to update user.");
            ViewData["ErrorMessage"] = "Unable to update user.";
        }

        if (addressResult.ContentResult is AddressEntity address)
        {
            var user = await _userManager.GetUserAsync(User);
            if ( user != null)
            {
                user.AddressId = address.Id;
                var updateUserResult = await _userManager.UpdateAsync(user);
                if (!updateUserResult.Succeeded)
                {
                    ModelState.AddModelError("Update failed", "Unable to update user address.");
                    ViewData["ErrorMessage"] = "Unable to update user address";
                    return View(viewModel);
                }
            }
        }




        return RedirectToAction("Details", "Account", viewModel);
    }
}
