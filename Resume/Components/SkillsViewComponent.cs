namespace Resume.Web.Components
{
    public class SkillsViewComponent:ViewComponent
    {
        #region Fields

        private readonly ISkillsService _skillsService;


        #endregion

        #region Constructor
        public SkillsViewComponent(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }
        #endregion

        #region Methods


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var skills=await _skillsService.GetSkillsInfoShowInHomeAsync();
            return View("skills",skills);
        }
        #endregion
    }
}
