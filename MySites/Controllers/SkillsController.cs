using Entities.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using System.Data;

namespace MySites.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillsController : Controller
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SkillsEkle(Skills skills)
        {
            await _skillsService.CreateAsync(skills);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SkillsGuncelle(Skills skills)
        {
            await _skillsService.UpdateAsync(skills);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SkillsSil(int id)
        {
            await _skillsService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> SkillsGetAll()
        {
            var skillsData = await _skillsService.GetAllAsync();
            return Json(new { data = skillsData });
        }
    }
}
