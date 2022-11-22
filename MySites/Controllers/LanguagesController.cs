using Entities.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using Service.Services.Concrete;

namespace MySites.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguagesService _languageService;

        public LanguagesController(ILanguagesService languageService)
        {
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LanguagesEkle(Languages languages)
        {
            await _languageService.CreateAsync(languages);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> LanguagesGuncelle(Languages languages)
        {
            await _languageService.UpdateAsync(languages);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> LanguagesSil(int id)
        {
            await _languageService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> LanguagesGetAll()
        {
            var languagesData = await _languageService.GetAllAsync();
            return Json(new { data = languagesData });
        }
    }
}
