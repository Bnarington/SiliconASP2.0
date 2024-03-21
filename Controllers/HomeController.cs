﻿using Microsoft.AspNetCore.Mvc;
using SiliconASP.ViewModels.Sections;
using SiliconASP.ViewModels.Sections.Components;
using SiliconASP.ViewModels.Sections.Views;

namespace SiliconASP.Controllers;

public class HomeController : Controller
{
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

            Features = new FeaturesViewModel
            {
                Id = "Features",
                Title = "What Do You Get with Our Tool?",
                TitleText = "Make sure all your tasks are organized so you can set the priorities and focus on important.",
                FeatureCards = [
                    new()
                    {
                        Title = "Comments on Tasks",
                        Text = "Id mollis consectetur congue egestas <br> egestas suspendisse<br>  blandit justo.",
                        Image = new() { ImageURL = "Images/Icons/chat.svg", AltText = "Chat" },
                        Link = new() { ControllerName = "#", ActionName = "Index", Text = "" }
                    },
                    new()
                    {
                        Title = "Tasks Analytics",
                        Text = "Non imperdiet facilisis nulla tellus Morbi<br>  scelerisque eget<br>  adipiscing vulputate.",
                        Image = new() { ImageURL = "Images/Icons/presentation.svg", AltText = "Presentation" },
                        Link = new() { ControllerName = "#", ActionName = "Index", Text = "" }
                    },
                    new()
                    {
                        Title = "Multiple Assignees",
                        Text = "A elementum, imperdiet enim,<br>  pretium etiam facilisi<br>  in aenean quam mauris.",
                        Image = new() { ImageURL = "Images/Icons/add-group.svg", AltText = "Add group" },
                        Link = new() { ControllerName = "#", ActionName = "Index", Text = "" }
                    },
                    new()
                    {
                        Title = "Notifications",
                        Text = "Diam, suspendisse velit cras ac. <br> Lobortis diam volutpat,<br>  eget pellentesque viverra.",
                        Image = new() { ImageURL = "Images/Icons/bell.svg", AltText = "Bell" },
                        Link = new() { ControllerName = "#", ActionName = "Index", Text = "" }
                    },
                    new()
                    {
                        Title = "Sections & Subtasks",
                        Text = "Mi feugiat hac id in. <br> Sit elit placerat lacus nibh<br> lorem ridiculus lectus.",
                        Image = new() { ImageURL = "Images/Icons/test.svg", AltText = "Test" },
                        Link = new() { ControllerName = "#", ActionName = "Index", Text = "" }
                    },
                    new()
                    {
                        Title = "Data Security",
                        Text = "Aliquam malesuada neque eget<br>  elit nulla vestibulum nunc cras.",
                        Image = new() { ImageURL = "Images/Icons/shield.svg", AltText = "Shield" },
                        Link = new() { ControllerName = "#", ActionName = "Index", Text = "" }
                    }

                    ]
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


        ViewData["title"] = viewModel.Title;
        return View(viewModel);
    }
}
