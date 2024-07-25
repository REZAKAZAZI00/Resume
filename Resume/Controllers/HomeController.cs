using Resume.Web.Controllers;

namespace Resume.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IEducationService _educationService;
        private readonly ISkillsService _skillsService;
        private readonly IWorkExperiencesService _workExperiencesService;
        #endregion

        #region Constructor
        public HomeController(IUserService userService, ISkillsService skillsService, IEducationService educationService, IWorkExperiencesService workExperiencesService)
        {
            _userService = userService;
            _skillsService = skillsService;
            _educationService = educationService;
            _workExperiencesService = workExperiencesService;
        }
        #endregion

        [HttpGet("")]
        [HttpGet("/index")]
        [HttpGet("/home/index")]
        public async Task<IActionResult> Index()
        {
            var user= await _userService.GetUserForShowAsync();
            ViewData[Data] = user;
            ViewData["Skills"]=await _skillsService.GetSkillsInfoShowInHomeAsync();
            ViewData["Educations"]=await _educationService.GetEducationsAsync();
            ViewData["WorkEx"]=await _workExperiencesService.GetWorkExperiencesAsync(); 
            return View();
        }

        
    }
}
