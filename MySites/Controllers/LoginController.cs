using Core.Manager;
using Entities.Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySites.Extensions;

namespace MySites.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAccessManager _accessManager;
        private readonly IClaimsManager _claimsManager;
        public LoginController(IAccessManager accessManager, IClaimsManager claimsManager)
        {
            _accessManager = accessManager;
            _claimsManager = claimsManager;
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("denied")]
        [AllowAnonymous]
        public async Task<IActionResult> Denied()
        {
            await HttpContext.SignOutAsync(); return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string Username, string Password)
        {
            var user = await _accessManager.Access(Username, Password);
            if (user != null)
            {
                HttpContext.Session.SetObject(user, "aktifKullanıcı");
                var kullanici = HttpContext.Session.GetObject<Users>("aktifKullanıcı");
                await HttpContext.SignInAsync(await _claimsManager.CreateClaim(kullanici));
                return Redirect("/AdminHome/Index");
            }
            TempData["Error"] = "Hatalı Kullanıcı Adı veya Şifresi";
            return View("Index");
        }
    }
}
