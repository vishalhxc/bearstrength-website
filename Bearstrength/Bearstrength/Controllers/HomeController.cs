using Microsoft.AspNetCore.Mvc;

namespace Bearstrength.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "About page";
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Contact page";
            return View();
        }
    }
}