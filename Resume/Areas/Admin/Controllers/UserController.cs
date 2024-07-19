using Resume.Core.DTOs.User;

namespace Resume.Web.Areas.Admin.Controllers;
[Area("Admin")]
public class UserController : Controller
{
    #region Fields
    private readonly IUserService _userService;
    #endregion

    #region Constructor

    public UserController(IUserService userService)
    {
         _userService = userService;
    }
    #endregion


    #region List

    public async Task<IActionResult> List()
    {
        return View();
    }
    #endregion

    #region Create


    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Create(CreateUserViewModel model)
    { 
       var result=_userService.Create(model);
      return View(result);
    }
    #endregion

    #region Update


    public async Task<IActionResult> Update(int id)
    {
        return View();

    }

    public async Task<IActionResult> Update(EditUserViewModel model)
    {

        return View(model);
    }
    #endregion

}
