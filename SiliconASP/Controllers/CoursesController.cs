using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SiliconASP.Controllers
{

    public class CoursesController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
    {

        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;

        [Route("/Courses")]
        public IActionResult Courses()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToAction("SignIn", "Auth");

            return View();
        }

        //public IActionResult Categories()
        //{
        //    var categories = db.Categories.ToList();
        //    return View(categories);
        //}

        //public IActionResult Search(string serachQuery, string category)
        //{
        //    var courses = db.Courses.AsQueryablle();

        //    if(!string.IsNullOrEmpty(serachQuery))
        //    {
        //        courses = courses.Where(c => c.Title.Contains(serachQuery));
        //    }

        //    if (!string.IsNullOrEmpty(category) && category != "all-categories")
        //    {
        //        courses = courses.Where(c => c.Category == category);
        //    }

        //    return View(courses.ToList());
        //}
    }
}
