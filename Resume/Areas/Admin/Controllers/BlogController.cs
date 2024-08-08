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
    #endregion
}
