using Entities.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;

namespace MySites.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperiencesService _experiencesService;

        public ExperienceController(IExperiencesService experiencesService)
        {
            _experiencesService = experiencesService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ExperienceEkle(Experiences experiences)
        {
            await _experiencesService.CreateAsync(experiences);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ExperienceGuncelle(Experiences experiences)
        {
            await _experiencesService.UpdateAsync(experiences);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> ExperienceSil(int id)
        {
            await _experiencesService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ExperienceGetAll()
        {
            var experienceData = await _experiencesService.GetAllAsync();
            return Json(new { data = experienceData });
        }
    }
}
