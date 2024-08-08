namespace Resume.Web.Components
{
    public class CategoriesViewComponent:ViewComponent
    {
        #region Fields

        private readonly ICategoryService _categoryService;


        #endregion

        #region Constructor

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var reslut = await _categoryService.GetCategoriesForShowHomeAsync();
            return View("Categories", reslut);
        }
        #endregion
    }
}
