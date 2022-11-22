using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MySites.Controllers
{
    [Authorize(Roles = "Admin")]
    public class _LayoutAdminController : Controller
    {
        public IActionResult _LayoutAdmin()
        {
            return View();
        }
    }
}
