namespace Resume.Web.Areas.Admin.Controllers;
[Area("admin")]
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
    [HttpGet("/admin/contactus")]
    public async Task<ActionResult<OutPutModel<FilterContactUsViewModel>>> List(FilterContactUsViewModel model)
    {
        var result = await _contactUsService.FilterAsync(model);

        return View(result);
    }
    #endregion

    #region Details

    [HttpGet("/admin/contactus/details/{id}")]
    public async Task<ActionResult<OutPutModel<ContactUsDetailsViewModel>>> Details(int id)
    {

        var result=await _contactUsService.GetByIdAsync(id);

        return View(result.Result);
    }

    [HttpPost("/admin/contactus/details/{id}")]
    public async Task<ActionResult> Details(ContactUsDetailsViewModel model)
    {
        if(!ModelState.IsValid)
            return View(model);
        
        await _contactUsService.AnswerAsync(model);
       
        return RedirectToAction("List");
    }

    #endregion

    #endregion
}
