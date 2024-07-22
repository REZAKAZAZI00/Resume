namespace Resume.Web.Areas.Admin.Controllers;

public class ContactUsController : AdminBaseController
{
    #region Fields
    private readonly IContactUsService _contactUsService;


    #endregion


    #region Constructor
    public ContactUsController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }
    #endregion


    #region Actions

    #region List

    public async Task<ActionResult<OutPutModel<FilterContactUsViewModel>>> List(FilterContactUsViewModel model)
    {
        var result = await _contactUsService.FilterAsync(model);

        return View(result);
    }
    #endregion

    #region Details

    public async Task<ActionResult<OutPutModel<ContactUsDetailsViewModel>>> Details(int id)
    {

        var result=await _contactUsService.GetByIdAsync(id);

        return View(result);
    }


    public async Task<ActionResult> Details(ContactUsDetailsViewModel model)
    {
        if(!ModelState.IsValid)
            return View(model);

        return View(model);
    }

    #endregion

    #endregion
}
