
namespace Resume.Web.Areas.Admin.Controllers;
[Area("admin")]
public class CategoryController : AdminBaseController
{
    #region Fields
    private readonly ICategoryService _categoryService;


    #endregion

    #region Constructor
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    #endregion

    #region Actions

    #region Filter

    [HttpGet("/admin/categories")]
    public async Task<IActionResult> List(FilterCategoryViewModel model)
    {
        var result = await _categoryService.FilterAsync(model);

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

    [HttpGet("/admin/categories/create")]
    public async Task<IActionResult> Create()
    {
        return View();
    }


    [HttpPost("/admin/categories/create")]
    public async Task<IActionResult> Create(CreateCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var result = await _categoryService.CreateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }


    #endregion

    #region Update
    [HttpGet("/admin/categories/update/{id}")]
    public async Task<IActionResult> Update(int id)
    {
        var result = await _categoryService.GetForUpdateByIdAsync(id);

        return View(result);
    }


    [HttpPost("/admin/categories/update/{id}")]
    public async Task<IActionResult> Update(UpdateCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _categoryService.UpdateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }

    #endregion

    #region Delete
    [HttpGet("/admin/categories/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.GetForDeleteByIdAsync(id);

        return View(result);
    }


    [HttpPost("/admin/categories/delete/{id}")]
    public async Task<IActionResult> Delete(DeleteCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _categoryService.DeleteAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }
    #endregion
    #endregion


}
