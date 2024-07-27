namespace Resume.Controllers
{
    public class HomeController : SiteBaseController
    {
        #region Fields
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public HomeController(IUserService userService)
        {
            _userService = userService;
            
        }
        #endregion


        #region Actions

        
        [HttpGet("")]
        [HttpGet("/index")]
        [HttpGet("/home/index")]
        public async Task<IActionResult> Index()
        {
            var user= await _userService.GetUserForShowAsync();
            ViewData[Data] = user;
            return View();
        }

        #endregion
    }
}
