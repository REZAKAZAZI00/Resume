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
    [HttpGet("/admin/skills/create")]
    public async Task<IActionResult> Create()
    {
        
        return View();
    }

    [HttpPost("/admin/skills/create")]
    public async Task<IActionResult> Create(CreateSkillsViewModel model)
    {
        var result = await _skillsService.CreateAsync(model);

        ViewData["result"]=result;
        return View();
    }
    #endregion

    #region Update

    [HttpGet("/admin/skills/update/{id}")]
    public async Task<IActionResult> Update(int id)
    {
        var result=await _skillsService.GetSkillByIdAsync(id);
        return View(result);
    }

    [HttpPost("/admin/skills/update")]
    public async Task<IActionResult> Update(UpdateSkillsViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);
        var result = await _skillsService.UpdateAsync(model);

        ViewData["result"] = result;
        return View();
    }
    #endregion

    #region Delete

    #endregion


    #endregion
}
