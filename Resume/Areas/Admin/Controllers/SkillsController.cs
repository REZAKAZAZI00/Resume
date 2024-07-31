namespace Resume.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class SkillsController : Controller
{
    #region Fields
    private readonly ISkillsService _skillsService;
    #endregion

    #region Constructor
    public SkillsController(ISkillsService skillsService)
    {
        _skillsService = skillsService;
    }
    #endregion




    #region Actions

    #region Filter
    [HttpGet("/admin/skills")]

    public async Task<IActionResult> List(FilterSkillsViewModel model)
    {
       var result=await _skillsService.FilterAsync(model);

        return View(result);
    }

    #endregion

    #region Create

    #endregion

    #region Update

    #endregion

    #region Delete

    #endregion


    #endregion
}
