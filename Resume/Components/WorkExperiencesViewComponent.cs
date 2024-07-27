namespace Resume.Web.Components;
public class WorkExperiencesViewComponent : ViewComponent
{
    #region Fields

    private readonly IWorkExperiencesService _workExperiencesService;
    #endregion

    #region Constructor


    public WorkExperiencesViewComponent(IWorkExperiencesService workExperiencesService)
    {
        _workExperiencesService = workExperiencesService;
    }
    #endregion


    #region Methods

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var workExp=await _workExperiencesService.GetWorkExperiencesAsync();
        return View("WorkExperiences", workExp);
    }

    #endregion
}
