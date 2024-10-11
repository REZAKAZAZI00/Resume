namespace Resume.Web.Components
{
    public class PopularBlogViewComponent:ViewComponent
    {
        #region Fields

        private readonly IBlogService _blogService;


        #endregion

        #region constructor

        public PopularBlogViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var educations = await _blogService.GetPopularBlogsAsync();
            return View("PopularBlog", educations);
        }

        #endregion
    }
}
