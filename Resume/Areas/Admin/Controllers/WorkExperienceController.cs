using Newtonsoft.Json;

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
    public async Task<IActionResult> List(FilterWorkExperiencesViewModel model)
    {
        var result=await _workExperiencesService.FilterAsync(model);

        var resultJson = TempData["result"] as string;
        if (resultJson != null)
        {
            var result2 = JsonConvert.DeserializeObject<OutPutModel<bool>>(resultJson);
            ViewData["result"] = result2;
        }

        return View(result);
    }
    #endregion

    #region Carete
    [HttpGet("/admin/Experiences/Create")]
    public async Task<IActionResult> Create()
    {
        
        return View();
    }

    [HttpPost("/admin/Experiences/Create")]
    public async Task<IActionResult> Create(CreateWorkExperiencesViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);

        var result = await _workExperiencesService.CreateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");
    }

    #endregion

    #region Update
    [HttpGet("/admin/experiences/update/{id}")]
    public async Task<IActionResult> Update(int id)
    {
        var result=await _workExperiencesService.GetForUpdateAsync(id);

        return View(result);
    }

    [HttpPost("/admin/experiences/update/{id}")]
    public async Task<IActionResult> Update(UpdateWorkExperiencesViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _workExperiencesService.UpdateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }
    #endregion


    #region Delete
    [HttpGet("/admin/experiences/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _workExperiencesService.GetForDeleteAsync(id);

        return View(result);
    }

    [HttpPost("/admin/experiences/delete/{id}")]
    public async Task<IActionResult> Delete(DeleteWorkExperiencesViewModel model)
    {

        var result = await _workExperiencesService.DeleteAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }
    #endregion
    #endregion
}
