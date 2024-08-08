
namespace Resume.Web.Areas.Admin.Controllers;
[Area("admin")]
public class ProjectController : AdminBaseController
{
    #region Fields

    private readonly IProjectService _projectService;
    #endregion

    #region Constructor
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    #endregion


    #region Actions

    #region Filter

    [HttpGet("/admin/projects")]
    public async Task<IActionResult> List(FilterProjectViewModel model)
    {
        var result = await _projectService.FilterAsync(model);

        var resultJson = TempData["result"] as string;
        if (resultJson != null)
        {
            var result2 = JsonConvert.DeserializeObject<OutPutModel<bool>>(resultJson);
            ViewData["result"] = result2;
        }
        return View(result);
    }
    #endregion

    #region Craete

    [HttpGet("/admin/projects/create")]
    public async Task<IActionResult> Create()
    {
        var category = await _projectService.GetCategoryForManageProductAsync();
        ViewData["category"] =new SelectList(category, "Value", "Text");

        return View();
    }


    [HttpPost("/admin/projects/create")]
    public async Task<IActionResult> Create(CreateProjectViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var result = await _projectService.CreateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }


    #endregion

    #region Update
    [HttpGet("/admin/projects/update/{id}")]
    public async Task<IActionResult> Update(int id)
    {
        var result = await _projectService.GetProjectForUpdateByIdAsync(id);
        var category = await _projectService.GetCategoryForManageProductAsync();
        ViewData["category"] = new SelectList(category, "Value", "Text",result.CategoryId);

        return View(result);
    }


    [HttpPost("/admin/projects/update/{id}")]
    public async Task<IActionResult> Update(UpdateProjectViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _projectService.UpdateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }

    #endregion

    #region Delete
    [HttpGet("/admin/projects/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _projectService.GetProjectForDeleteByIdAsync(id);

        return View(result);
    }


    [HttpPost("/admin/projects/delete/{id}")]
    public async Task<IActionResult> Delete(DeleteProjectViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _projectService.DeleteAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }
    #endregion



    #endregion
}
