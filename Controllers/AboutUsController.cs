using Microsoft.AspNetCore.Mvc;

namespace JobSite.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
