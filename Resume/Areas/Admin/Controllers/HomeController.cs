namespace Resume.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController:AdminBaseController
    {
        #region Actions
        public IActionResult Index()
        {
            return View();
        }
        #endregion


    }
}
