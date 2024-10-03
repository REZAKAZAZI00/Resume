namespace Resume.Web.Controllers;
public class BlogController : SiteBaseController
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

    [HttpGet("/blogs")]
    public async Task<IActionResult> List(FilterBlogViewModel model)
    {
        var reslut=await _blogService.FilterAsync(model);
        return View(reslut);
    }
    [HttpGet("/blog/{id}")]
    public async Task<IActionResult> blog(int id)
    {

        var result=await _blogService.GetBlogByIdAsync(id);

        return View(result);
    }

    #endregion

}
