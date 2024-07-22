

namespace Resume.Web.Controllers;
public class ContactUsController : SiteBaseController
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

    #region ContactUs
    [HttpGet("/contact-us")]
    public async Task<IActionResult> ContactUs()
    {
        return View();
    }

    [HttpPost("/contact-us")]
    public async Task<IActionResult> ContactUs(CreateContactUsViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _contactUsService.CreateAsync(model);

        ViewData[Data] = result;
        
        return View();
    }

    #endregion
    #endregion
}