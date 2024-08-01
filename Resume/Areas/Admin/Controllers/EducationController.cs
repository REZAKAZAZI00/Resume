namespace Resume.Web.Areas.Admin.Controllers;

[Area("admin")]
public class EducationController : AdminBaseController
{
	#region Fields

	private readonly IEducationService _educationService;

    #endregion

    #region Constructor

    public EducationController(IEducationService educationService)
    {
        _educationService = educationService;
    }
    #endregion

    #region Actions

    #region List

    [HttpGet("/admin/educations")]
    public async Task<IActionResult> List(FilterEducationViewModel model)
    {

        var result=await _educationService.FilterAsync(model);
        return View(result);
    }
    #endregion


    #region Create


    [HttpGet("/admin/educations/create")]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost("/admin/educations/create")]
    public async Task<IActionResult> Create(CreateEducationViewModel model)
    {
        var result=await _educationService.CreateAsync(model);
        ViewData["result"] = result;
        return View();
    }



    #endregion


    #region Update
    [HttpGet("/admin/educations/update")]
    public async Task<IActionResult> Update()
    {
        return View();
    }

    [HttpPost("/admin/educations/update")]
    public async Task<IActionResult> Update(UpdateEducationViewModel model)
    {
        var result = await _educationService.UpdateAsync(model);
        ViewData["result"] = result;
        return View();
    }
    #endregion

    #region Delete
    [HttpGet("/admin/educations/delete")]
    public async Task<IActionResult> Delete()
    {
        return View();
    }
    #endregion

    #endregion
}
