using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconASP.ViewModels.Sections;


namespace SiliconASP.Controllers
{
    [Authorize]
    public class CoursesController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, HttpClient httpClient) : Controller
    {

        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly HttpClient _httpClient = httpClient;

        [Route("/Courses")]
        public async Task<IActionResult> Courses()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("SignIn", "Auth");

            var viewModel = new CourseIndexViewModel();

            var response = await _httpClient.GetAsync("https://localhost:7202/api/courses");
            if (response.IsSuccessStatusCode)
            {
                var courses = JsonConvert.DeserializeObject<IEnumerable<CoursesViewModel>>(await response.Content.ReadAsStringAsync());
                if (courses != null && courses.Any())
                    viewModel.Courses = courses;
            }

            return View(viewModel);
        }
    }
}
