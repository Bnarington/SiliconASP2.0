using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconASP.ViewModels.Sections;

namespace SiliconASP.Controllers;

[Authorize]
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

        if (ModelState.IsValid != false)
        {
            var userEntity = await _userManager.GetUserAsync(User);
            var addressEntity = await _addressService.GetAddressEntityAsync(userEntity!.AddressId);
            var address = (AddressEntity)addressEntity.ContentResult!;
            string imageBase64 = userEntity.ProfileImage != null ? Convert.ToBase64String(userEntity.ProfileImage) : null!;
            string profileImgSrc = $"data:image/jpeg;base64, {imageBase64}";

            if (userEntity != null && address != null)
            {
                var viewModel = new AccountDetailsViewModel()
                {
                    User = userEntity!,
                    Address = (AddressEntity)addressEntity.ContentResult!,
                    BasicInfo = new AccountBasicInfoModel
                    {
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Email = userEntity.Email!,
                        Phone = userEntity.PhoneNumber!,
                        Bio = userEntity.Bio,
                        ProfileImageSrc = profileImgSrc
                    },
                    AddressInfo = new AccountAdressInfoModel
                    {
                        AddressLine_1 = address.StreetName!,
                        AddressLine_2 = address.OptionalStreet,
                        PostalCode = address.PostalCode!,
                        City = address.City!
                    }
                };

                return View(viewModel);
            }
            else if (userEntity != null && address == null)
            {
                var viewModel = new AccountDetailsViewModel()
                {
                    User = userEntity!,
                    Address = (AddressEntity)addressEntity.ContentResult!,
                    BasicInfo = new AccountBasicInfoModel
                    {
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        Email = userEntity.Email!,
                        Phone = userEntity.PhoneNumber!,
                        Bio = userEntity.Bio,
                        ProfileImageSrc = profileImgSrc
                    }

                };
                return View(viewModel);
            }
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
    {
        var user = await _userManager.FindByEmailAsync(viewModel.BasicInfo.Email!);
        if (user != null && TryValidateModel(viewModel.BasicInfo))
        {
            user.FirstName = viewModel.BasicInfo.FirstName;
            user.LastName = viewModel.BasicInfo.LastName;
            user.PhoneNumber = viewModel.BasicInfo.Phone;
            user.Bio = viewModel.BasicInfo.Bio;
        }

        if (viewModel.BasicInfo.ProfileImage != null)
        {
            byte[] fileBytes;
            using var memoryStream = new MemoryStream();
            await viewModel.BasicInfo.ProfileImage.CopyToAsync(memoryStream);
            fileBytes = memoryStream.ToArray();

            user!.ProfileImage = fileBytes;
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
        var addressResult = await _addressService.GetOrCreateAddressAsync(viewModel.AddressInfo.AddressLine_1, viewModel.AddressInfo.AddressLine_2!, viewModel.AddressInfo.PostalCode, viewModel.AddressInfo.City);

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
