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


    #endregion

}
