namespace Resume.Web.Areas.Admin.Controllers;
[Area("admin")]
public class BlogController : AdminBaseController
{
	#region Fields

	private readonly IBlogService _blogService;


    #endregion

    #region Constructor
    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }
    #endregion


    #region Actions

    #region Filter

    [HttpGet("/admin/blogs")]
    public async Task<IActionResult> List(FilterBlogViewModel model)
    {
        var result = await _blogService.FilterAsync(model);

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

    [HttpGet("/admin/blogs/create")]
    public async Task<IActionResult> Create()
    {
        var category = await _blogService.GetCategoryForManageBlogAsync();
        ViewData["category"] = new SelectList(category, "Value", "Text");

        return View();
    }


    [HttpPost("/admin/blogs/create")]
    public async Task<IActionResult> Create(CreateBlogViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var result = await _blogService.CreateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }


    #endregion

    #region Update
    [HttpGet("/admin/blogs/update/{id}")]
    public async Task<IActionResult> Update(int id)
    {
        var result = await _blogService.GetBlogForUpdateAsync(id);
        var category = await _blogService.GetCategoryForManageBlogAsync();
        ViewData["category"] = new SelectList(category, "Value", "Text", result.CategoryId);

        return View(result);
    }


    [HttpPost("/admin/blogs/update/{id}")]
    public async Task<IActionResult> Update(UpdateBlogViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _blogService.UpdateAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }

    #endregion

    #region Delete
    [HttpGet("/admin/blogs/delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _blogService.GetBlogForDeleteAsync(id);

        return View(result);
    }


    [HttpPost("/admin/blogs/delete/{id}")]
    public async Task<IActionResult> Delete(DeleteBlogViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _blogService.DeleteAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("List");

    }
    #endregion

    #region Category

    #region Filter

    [HttpGet("/admin/blogcategories")]
    public async Task<IActionResult> ListCategories(FilterBlogCategoryViewModel model)
    {
        var result = await _blogService.FilterAsync(model);

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

    [HttpGet("/admin/blogcategories/createcategory")]
    public async Task<IActionResult> CreateCategory()
    {
        
        return View();
    }


    [HttpPost("/admin/blogcategories/createcategory")]
    public async Task<IActionResult> CreateCategory(CreateBlogCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var result = await _blogService.CreateBlogCategoryAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("ListCategories");

    }


    #endregion

    #region Update
    [HttpGet("/admin/blogcategories/updatecategory/{id}")]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        var result = await _blogService.GetBlogCategoryForUpdateAsync(id);
        
        return View(result);
    }


    [HttpPost("/admin/blogcategories/updatecategory/{id}")]
    public async Task<IActionResult> UpdateCategory(UpdateBlogCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _blogService.UpdateBlogCategoryAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("ListCategories");

    }

    #endregion

    #region Delete
    [HttpGet("/admin/blogcategories/deletecategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var result = await _blogService.GetBlogCategoryForDeleteAsync(id);

        return View(result);
    }


    [HttpPost("/admin/blogcategories/deletecategory/{id}")]
    public async Task<IActionResult> DeleteCategory(DeleteBlogCategoryViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _blogService.DeleteBlogCategoryAsync(model);
        TempData["result"] = JsonConvert.SerializeObject(result);
        return RedirectToAction("ListCategories");

    }
    #endregion
    #endregion
    #endregion
}
