namespace Resume.Web.Controllers
{
    public class AccountController : SiteBaseController
    {

        #region Files
        private readonly IUserService _userService;



        #endregion

        #region Constructor 
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion


        #region Actions

        #region Login
        [HttpGet("/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home",new {area="admin"});
            }
            return View();
        }

        [HttpPost("/login")]
        public async Task<ActionResult<OutPutModel<bool>>> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result=await _userService.LoginAsync(model);
            TempData[StatusCode] = result.StatusCode;
            TempData[Message] = result.Message;
          
            return View(model);
        }
        #endregion


        #region Logout
        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        #endregion

        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
