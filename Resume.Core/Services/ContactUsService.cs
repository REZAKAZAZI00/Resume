
using Resume.DataLayer.Entities.ContactUs;

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


    public async Task<OutPutModel<bool>> CreateAysnc(CreateContactUsViewModel model)
    {
        try
        {
            var newContactUs = new ContactUs()
            {
                CreateDate = DateTime.Now,
                LastName = model.LastName,
                Description = model.Description,
                Email = FixedText.FexedEmail(model.Email),
                Answer = null,
                FirstName = model.FirstName,
                PhoneNumber = model.PhoneNumber,
                Title = model.Title
            };
            _context.ContactUs.Add(newContactUs);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Message = "",
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

    public async Task<OutPutModel<FilterContactUsViewModel>> FilterAysnc(FilterContactUsViewModel model)
    {
        try
        {
            var query = _context.ContactUs
               .AsNoTracking()
               .AsQueryable();

            string email = $"%{model.Email}%";
            if (!string.IsNullOrEmpty(model.Email))
                query = query.Where(c => EF.Functions.Like( c.Email,email));

            string phoneNumber = $"%{model.Phone}%";
            if (!string.IsNullOrEmpty(model.Phone))
                query = query.Where(c => EF.Functions.Like(c.PhoneNumber, phoneNumber));


            string firstName = $"%{model.FirstName}%";
            if (!string.IsNullOrEmpty(model.FirstName))
                query = query.Where(c => EF.Functions.Like(c.FirstName,firstName));

            string lastName = $"%{model.LastName}%";
            if (!string.IsNullOrEmpty(model.LastName))
                query = query.Where(c => EF.Functions.Like(c.LastName, lastName));

            string title=$"%{model.Title}%";
            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(c => EF.Functions.Like(c.Title,title));

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


}
