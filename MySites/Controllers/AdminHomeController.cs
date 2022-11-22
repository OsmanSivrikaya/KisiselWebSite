using Microsoft.AspNetCore.Mvc;

namespace MySites.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
