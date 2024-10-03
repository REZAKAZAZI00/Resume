namespace Resume.Web.Controllers;
public class AboutMeController :SiteBaseController
{
    #region Filelds

    private readonly IUserService _userService;
	#endregion

	#region Constructor
	public AboutMeController(IUserService userService)
	{
		_userService = userService;
	}
	#endregion


	#region Actions

	#region AboutMe
	[HttpGet("about")]
    public async Task<IActionResult> AboutMe()
    {
		ViewData["Data"]=await _userService.GetUserForShowAsync();

		return View();
    }
    #endregion
    #endregion
}
