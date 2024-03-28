using Microsoft.AspNetCore.Mvc;

namespace SiliconASP.Controllers
{
    public class CoursesController : Controller
    {
        [Route("/Courses")]
        public IActionResult Courses()
        {
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
