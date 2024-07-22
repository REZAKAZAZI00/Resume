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
    [HttpGet("/admin/users")]
    public async Task<IActionResult> List(FilterUserViewModel filter)
    {
        var result=await _userService.FilterAsync(filter);

        return View(result);
    }
    #endregion

    #region Create


    public IActionResult Create()
    {
        return View();
    }

    public async Task<ActionResult<OutPutModel<bool>>> Create(CreateUserViewModel model)
    {
        if (!ModelState.IsValid)
             return View(model);

        var result =await _userService.Create(model);

 
        return View(result);
    }
    #endregion

    #region Update

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var user = await _userService.GetUserForEditByIdAsync(id);
        if (user is null)
            return NotFound();

        return View();

    }
    [HttpPost]
    public async Task<IActionResult> Update(EditUserViewModel model)
    {
        if (!ModelState.IsValid) 
            return View(model);
       
        var result=await _userService.UpdateAsync(model);
        return View(model);
    }
    #endregion

}
