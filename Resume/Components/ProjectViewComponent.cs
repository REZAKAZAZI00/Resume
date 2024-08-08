namespace Resume.Web.Components;

public class ProjectViewComponent:ViewComponent
{
	#region Fields

	private readonly IProjectService _projectService;


    #endregion

    #region Constructor
    public ProjectViewComponent(IProjectService projectService)
    {
        _projectService = projectService;
    }
    #endregion


    #region Methods


    public async Task<IViewComponentResult> InvokeAsync()
    {
        var reslut=await _projectService.GetProjectForShowHomeAsync();
        return View("project",reslut);
    }
    #endregion
}
