namespace Resume.Core.Services;

public class ContactUsService : IContactUsService
{
    #region Fields
    private readonly ResumeDbContext _context;
    private readonly ILogger<ContactUsService> _logger;

    #endregion


    #region Constructor
    public ContactUsService(ResumeDbContext context, ILogger<ContactUsService> logger)
    {
        _context = context;
        _logger = logger;
    }

  
    #endregion


    public async Task<OutPutModel<bool>> CreateAsync(CreateContactUsViewModel model)
    {
        try
        {
            var newContactUs = new ContactUs()
            {
                CreateDate = DateTime.Now,
                LastName = model.FirstName,
                Description = model.Description,
                Email = FixedText.FexedEmail(model.Email),
                Answer = null,
                FirstName = model.FirstName,
                PhoneNumber = model.PhoneNumber,
                Title = model.Title
            };
            _context.ContactUs.Add(newContactUs);
            await SaveAsync();

            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Message = "Send SuccessFully.",
                Result = true,
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = "خطای غیرمنتظره ای رخ داد مجدد تلاش کنید",

            };
        }
    }

    public async Task<OutPutModel<FilterContactUsViewModel>> FilterAsync(FilterContactUsViewModel model)
    {
        try
        {
            var query = _context.ContactUs
               .AsNoTracking()
               .AsQueryable();

            string email = $"%{model.Email}%";
            if (!string.IsNullOrEmpty(model.Email))
                query = query.Where(c => EF.Functions.Like(c.Email, email));

            string phoneNumber = $"%{model.Phone}%";
            if (!string.IsNullOrEmpty(model.Phone))
                query = query.Where(c => EF.Functions.Like(c.PhoneNumber, phoneNumber));


            string firstName = $"%{model.FirstName}%";
            if (!string.IsNullOrEmpty(model.FirstName))
                query = query.Where(c => EF.Functions.Like(c.FirstName, firstName));

            string lastName = $"%{model.LastName}%";
            if (!string.IsNullOrEmpty(model.LastName))
                query = query.Where(c => EF.Functions.Like(c.LastName, lastName));

            string title = $"%{model.Title}%";
            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(c => EF.Functions.Like(c.Title, title));

            switch (model.AnswerStatus)
            {
                case FilterContactUsAnswerStatus.All:
                    break;
                case FilterContactUsAnswerStatus.Answered:
                    query = query.Where(c => c.Answer != null);
                    break;
                case FilterContactUsAnswerStatus.NotAnswered:
                    query = query.Where(c => c.Answer == null);
                    break;

            }
            await model.Paging(query
                .Select(c => new ContactUsDetailsViewModel
                {

                    PhoneNumber = c.PhoneNumber,
                    Answer = c.Answer,
                    Description = c.Description,
                    Title = c.Title,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Id = c.Id,
                    CreateDate = c.CreateDate,
                }));

            return new OutPutModel<FilterContactUsViewModel>
            {
                StatusCode = 200,
                Message = "",
                Result = model
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<FilterContactUsViewModel>
            {
                StatusCode = 500,
                Result = null,
                Message = "خطای غیرمنتظره ای رخ داد مجدد تلاش کنید",

            };
        }
    }

    public async Task<OutPutModel<ContactUsDetailsViewModel>> GetByIdAsync(int id)
    {
        try
        {
            var contactUs = await _context.ContactUs
                .Where(c => c.Id == id)
                .Select(c => new ContactUsDetailsViewModel()
                {
                    Id = c.Id,
                    Answer = c.Answer,
                    Description = c.Description,
                    Title = c.Title,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    CreateDate = c.CreateDate
                })
                .SingleOrDefaultAsync();
            if (contactUs is null)
                return new OutPutModel<ContactUsDetailsViewModel>
                {
                    Result = null,
                    StatusCode = 404,
                    Message = "با ایدی وارد شد چیزی پیدا نشد"
                };

            return new OutPutModel<ContactUsDetailsViewModel>
            {
                StatusCode = 200,
                Message = "",
                Result = contactUs
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<ContactUsDetailsViewModel>
            {
                StatusCode = 500,
                Result = null,
                Message = "خطای غیرمنتظره ای رخ داد مجدد تلاش کنید",

            };
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }


    public async Task<OutPutModel<bool>> AnswerAsync(ContactUsDetailsViewModel model)
    {
        try
        {
           var contactUs=await _context.ContactUs.FindAsync(model.Id);

            if (contactUs is null)
                return new OutPutModel<bool>
                {
                    Result = false,
                    StatusCode=404,
                    Message=""
                };

            contactUs.Answer=model.Answer;
            _context.ContactUs.Update(contactUs);
            await SaveAsync();
            return new OutPutModel<bool>
            {
                Result = true,
                StatusCode = 200,
                Message = "Send SuccessFully."
			};
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                 StatusCode=500,
                 Result=false,
                 Message=""
            };
        }
    }

}
