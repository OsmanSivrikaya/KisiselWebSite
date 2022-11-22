using Microsoft.AspNetCore.Mvc;
using MySites.Models;
using Service.Services.Abstract;
using System.Diagnostics;

namespace MySites.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonalDataService _personalDataService;
        private readonly IIntroduceYourselfService _introduceYourselfService;
        private readonly IExpertisesService _expertiesService;
        private readonly IExperiencesService _experiencesService;
        private readonly IEducationsService _educationsService;
        private readonly ISkillsService _skillsService;
        private readonly ILanguagesService _languagesService;
        public HomeController(ILogger<HomeController> logger, IPersonalDataService personalDataService, IIntroduceYourselfService introduceYourselfService, IExpertisesService expertiesService, IExperiencesService experiencesService, IEducationsService educationsService, ISkillsService skillsService, ILanguagesService languagesService)
        {
            _logger = logger;
            _personalDataService = personalDataService;
            _introduceYourselfService = introduceYourselfService;
            _expertiesService = expertiesService;
            _experiencesService = experiencesService;
            _educationsService = educationsService;
            _skillsService = skillsService;
            _languagesService = languagesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PersonalDataGetAll()
        {
            var personalData = await _personalDataService.GetAllAsync();
            return Json(personalData);
        }
        [HttpGet]
        public async Task<IActionResult> IntroduceYourselfDataGetAll()
        {
            var ıntroduceYourselfData = await _introduceYourselfService.GetAllAsync();
            return Json(ıntroduceYourselfData);
        }
        [HttpGet]
        public async Task<IActionResult> ExpertiesDataGetAll()
        {
            var expertiesData = await _expertiesService.GetAllAsync();
            return Json(expertiesData);
        }
        [HttpGet]
        public async Task<IActionResult> ExperiencesDataGetAll()
        {
            var experiencesData = await _experiencesService.GetAllAsync();
            return Json(experiencesData.Where(x=>x.MainPageVisibility == true));
        }
        [HttpGet]
        public async Task<IActionResult> EducationsDataGetAll()
        {
            var educationsData = await _educationsService.GetAllAsync();
            return Json(educationsData.Where(x => x.MainPageVisibility == true));
        }
        [HttpGet]
        public async Task<IActionResult> SkillsDataGetAll()
        {
            var skillsData = await _skillsService.GetAllAsync();
            return Json(skillsData.Where(x => x.MainPageVisibility == true));
        }
        [HttpGet]
        public async Task<IActionResult> LanguagesDataGetAll()
        {
            var languagesData = await _languagesService.GetAllAsync();
            return Json(languagesData.Where(x => x.MainPageVisibility == true));
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}