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
        var result = await _contactUsService.FilterAysnc(model);

        return View(result);
    }
    #endregion

    #endregion
}
