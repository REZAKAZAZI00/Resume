using Resume.Web.Controllers;

namespace Resume.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region MyRegion

        #endregion
        private readonly IUserService _userService;
        private readonly ISkillsService _skillsService;
        #region Constructor
        public HomeController(IUserService userService, ISkillsService skillsService)
        {
            _userService = userService;
            _skillsService = skillsService;
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
            return View();
        }

        
    }
}
