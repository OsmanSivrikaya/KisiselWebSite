using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MySites.Controllers
{
    public class PersonelDataController : Controller
    {
        private readonly IPersonalDataRepository _personalDataRepository;
        public PersonelDataController(IPersonalDataRepository personalDataRepository)
        {
            _personalDataRepository = personalDataRepository;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PersonalDataGuncelle(PersonalData personalData)
        {
            personalData.Id = 1;
            await _personalDataRepository.UpdateAsync(personalData);
            return RedirectToAction("Index","PersonelData");
        }
    }
}
