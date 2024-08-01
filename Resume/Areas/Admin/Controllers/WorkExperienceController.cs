namespace Resume.Web.Areas.Admin.Controllers;
[Area("admin")]
public class WorkExperienceController : AdminBaseController
{
    #region Fields

    private readonly IWorkExperiencesService _workExperiencesService;
    #endregion

    #region Constructor
    public WorkExperienceController(IWorkExperiencesService workExperiencesService)
    {
        _workExperiencesService = workExperiencesService;
    }
    #endregion

    #region Actions

    #region List
    [HttpGet("/admin/Experiences")]
    public async Task<IActionResult> List()
    {

        return View();
    }
    #endregion
    #region Carete

    #endregion

    #region Update

    #endregion
    #region Delete

    #endregion
    #endregion
}
