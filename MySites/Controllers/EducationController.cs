using Entities.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Abstract;
using System.Data;

namespace MySites.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EducationController : Controller
    {
        private readonly IEducationsService _educationsService;

        public EducationController(IEducationsService educationsService)
        {
            _educationsService = educationsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EducationEkle(Educations educations)
        {
            await _educationsService.CreateAsync(educations);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EducationGuncelle(Educations educations)
        {
            await _educationsService.UpdateAsync(educations);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EducationSil(int id)
        {
            await _educationsService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EducationGetAll()
        {
            var educationData = await _educationsService.GetAllAsync();
            return Json(new { data = educationData });
        }
    }
}
