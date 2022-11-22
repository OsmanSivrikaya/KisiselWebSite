using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;

namespace MySites.Controllers
{
    public class LayoutController : Controller
    {
        private readonly IPersonalDataService _personalDataService;

        public LayoutController( IPersonalDataService personalDataService)
        {
            _personalDataService = personalDataService;
        }
        [HttpGet]
        public  IActionResult _Layout()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PersonalDataGetAll()
        {
            var personalData = await _personalDataService.GetAllAsync();
            return Json(personalData);
        }
    }
}
