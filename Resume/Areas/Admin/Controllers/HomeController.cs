using System.Web.Mvc;

namespace Resume.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
