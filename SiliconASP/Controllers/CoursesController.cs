using Microsoft.AspNetCore.Mvc;

namespace SiliconASP.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
