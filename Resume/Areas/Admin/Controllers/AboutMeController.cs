namespace Resume.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class AboutMeController : Controller
{
    #region Fields
    private readonly IAboutMeService _aboutMeService;

    #endregion

    #region Constructor

    public AboutMeController(IAboutMeService aboutMeService)
    {
        _aboutMeService = aboutMeService;
    }
    #endregion

    #region Actions


    [HttpGet("/admin/about")]
    public async Task<IActionResult> AboutMe()
    {
        var result = await _aboutMeService.GetInfoAsync();

        return View(result);
    }

    [HttpPost("/admin/About")]
    public async Task<IActionResult> AboutMe(AdminSideEditAboutMeViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _aboutMeService.UpdateAsync(model);
        ViewData["result"] = result;
        return View();
    }
    #endregion
}
