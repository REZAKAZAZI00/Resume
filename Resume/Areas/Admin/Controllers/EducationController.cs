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
        var resultJson = TempData["result"] as string;
        if (resultJson != null)
        {
            var result2 = JsonConvert.DeserializeObject<OutPutModel<bool>>(resultJson);
            ViewData["result"] = result2;
        }
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
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");
    }



    #endregion


    #region Update
    [HttpGet("/admin/educations/update/{id}")]
    public async Task<IActionResult> Update(int id)
    {
        var result=await _educationService.GetEducationForUpdateById(id);

        return View(result);
    }

    [HttpPost("/admin/educations/update/{id}")]
    public async Task<IActionResult> Update(UpdateEducationViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _educationService.UpdateAsync(model);
        TempData["result"] =JsonConvert.SerializeObject(result);

        return RedirectToAction("List");
    }
    #endregion

    #region Delete
    [HttpGet("/admin/educations/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var reslut=await _educationService.GetEducationForDeleteById(id);
        return View(reslut);
    }

    [HttpPost("/admin/educations/delete/{id}")]
    public async Task<IActionResult> Delete(DeleteEducationViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model); 

        var reslut = await _educationService.DeleteAsync(model);
        TempData["result"] =  JsonConvert.SerializeObject(reslut);

        return RedirectToAction("List");
    }


    #endregion

    #endregion
}
