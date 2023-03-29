using Microsoft.AspNetCore.Mvc;

namespace MyProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
