using NuGet.Versioning;

namespace Resume.Web.Components
{
    public class EducationViewComponent:ViewComponent
    {
        #region Fields

        private readonly IEducationService _educationService;


        #endregion

        #region Constructor
        public EducationViewComponent(IEducationService educationService)
        {
            _educationService = educationService;
        }
        #endregion


        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var educations=await _educationService.GetEducationsAsync();
            return View("Education",educations);
        }
        #endregion
    }
}
