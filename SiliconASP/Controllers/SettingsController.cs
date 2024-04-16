using Microsoft.AspNetCore.Mvc;

namespace SiliconASP.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult ChangeTheme(string theme)
        {
            var option = new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1),
            };
            Response.Cookies.Append("theme", theme, option);
            return Ok();
        }
    }
}
