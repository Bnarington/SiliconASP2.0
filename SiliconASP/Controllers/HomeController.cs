using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconASP.ViewModels.Sections;
using SiliconASP.ViewModels.Sections.Components;
using SiliconASP.ViewModels.Sections.Views;
using System.Net.Http;
using System.Text;
namespace SiliconASP.Controllers;

public class HomeController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, HttpClient httpClient) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly HttpClient _httpClient = httpClient;

    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel
        {
            Title = "Home",

            Showcase = new ShowcaseViewModel
            {

                Id = "Management",
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                BrandText = "Largest companies use our tool to work efficiently",
                Brands = [
                    new() { ImageURL = "Images/Brands/logoipsum.svg", AltText = "Logo 1" },
                    new() { ImageURL = "Images/Brands/logoipsum-1.svg", AltText = "Logo 2" },
                    new() { ImageURL = "Images/Brands/logoipsum-2.svg", AltText = "Logo 3" },
                    new() { ImageURL = "Images/Brands/logoipsum-3.svg", AltText = "Logo 4" }
                         ],
                Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" },
                ShowcaseImage = new ImageViewModel
                {
                    ImageURL = "Images/Dashboard.svg",
                    AltText = "Task management assasistant"
                }
            },

            Managework = new ManageWorkViewModel
            {
                Id = "Managework",
                Title = "Manage Your Work",
                Image = new ImageViewModel
                {
                    ImageURL = "Images/management-picture.svg",
                    AltText = "Management picture"
                },
                ManageList =
                [
                    new() { text = "Powerful project management", Image = new ImageViewModel { ImageURL = "Images/Icons/bx-check-circle.png", AltText = "Checkmark circle" } },
                    new() { text = "Transparent work management", Image = new ImageViewModel { ImageURL = "Images/Icons/bx-check-circle.png", AltText = "Checkmark Circle" } },
                    new() { text = "Manage work & focus on the most important tasks", Image = new ImageViewModel { ImageURL = "Images/Icons/bx-check-circle.png", AltText = "Checkmark Circle" } },
                    new() { text = "Track your progress with interactive charts", Image = new ImageViewModel { ImageURL = "Images/Icons/bx-check-circle.png", AltText = "Checkmark Circle" } },
                    new() { text = "Easiest way to track time spent on tasks", Image = new ImageViewModel { ImageURL = "Images/Icons/bx-check-circle.png", AltText = "Checkmark Circle" } },
                ],
                Link = new LinkViewModel
                {
                    ControllerName = "Manager",
                    ActionName = "Index",
                    Text = " Learn More <i class=\"fa-sharp fa-regular fa-arrow-right\" style=\"color: #ffffff;\"></i>"
                }
            },

            Downloads = new DownloadsViewModel
            {
                Id = "Downloads",
                Title = "Download Our App for Any Device",
                Image = new ImageViewModel() { ImageURL = "Images/downlads-picture.svg", AltText = "Picture of two phones with management and calander." },
                AppStore = new ReviewViewModel()
                {
                    Title = "App Store",
                    DescriptionTitle = "Editor's Choice",
                    Description = "rating 4.7, 187K+ reviews",
                    Stars =
                    [
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                    ],
                    Icon = new ImageViewModel { ImageURL = "Images/Icons/appstore.png", AltText = "" }

                },

                GoogleStore = new ReviewViewModel()
                {
                    Title = "Google Play",
                    DescriptionTitle = "App of the Day",
                    Description = "rating 4.8, 30K+ reviews",
                    Stars =
                    [
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                        new() { ImageURL = "Images/Icons/star.svg", AltText = "Star" },
                    ],
                    Icon = new ImageViewModel { ImageURL = "Images/Icons/googleplay.png", AltText = "" }

                }
            },

            Integrate = new IntegrateViewModel()
            {
                Title = "Integrate Top Work Tools",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam luctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.",
                IntegrateItem =
                [
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/Google/color.png", AltText = "Google" }, Description = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis." },
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/Zoom/color.png", AltText = "Zoom" }, Description = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor." },
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/Slack/color.png", AltText = "Slack" }, Description = "Id mollis consectetur congue egestas egestas suspendisse blandit justo." },
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/Gmail/color.png", AltText = "Gmail" }, Description = "Rutrum interdum tortor, sed at nulla. A cursus bibendum elit purus cras praesent." },
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/Trello/color.png", AltText = "Trello" }, Description = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna." },
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/MailChimp/color.png", AltText = "MailChimp" }, Description = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris." },
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/Dropbox/color.png", AltText = "Dropbox" }, Description = "Ut in turpis consequat odio diam lectus elementum. Est faucibus blandit platea." },
                    new() { Image = new ImageViewModel { ImageURL = "Images/Brands/Evernote/color.png", AltText = "Evernote" }, Description = "Faucibus cursus maecenas lorem cursus nibh. Sociis sit risus id. Sit facilisis dolor arcu." },
                ]
            },

            Newsletter = new NewsletterViewModel()
            {
                Title = "Don't Want to Miss Anything?",
                Description = "Sign up for one of our newsletters!",
                Image = new ImageViewModel { ImageURL = "Images/Icons/arrows.svg", AltText = "" },
                Options =
                [
                    new() { Name = "Daily Newsletter" },
                    new() { Name = "Advertising Updates" },
                    new() { Name = "Week in Review" },
                    new() { Name = "Event Updates" },
                    new() { Name = "Startups Weekly" },
                    new() { Name = "Podcasts" },
                ],
                TermsLink = new LinkViewModel() { ControllerName = "Terms", ActionName = "Terms", Text = "terms" },
                PrivacyLink = new LinkViewModel() { ControllerName = "Privay", ActionName = "Privacy", Text = "Privacy" }
            },

        };

        if (TempData.TryGetValue("ErrorMessage", out object? value))
        {
            ModelState.AddModelError("WrongEmail", value!.ToString()!);
        }


        ViewData["title"] = viewModel.Title;
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(NewsletterViewModel model){

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Invalid Email address.";
            return Redirect(Url.Action("Index", "Home") + "#newsletter");
        }

        var email = model.Newsletter!.Email;

        var url = $"https://localhost:7202/api/subscribe?email={(Uri.EscapeDataString(email))}";

        var response = await _httpClient.PostAsync(url, null);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        } else
        {
            TempData["ErrorMessage"] = "Invalid Email address.";
            return RedirectToAction("Index");
        }
    }
}