
namespace Resume.Core.Services.InterFace;

public interface IContactUsService
{

    Task<OutPutModel<bool>> CreateAsync(CreateContactUsViewModel model); 

    Task<OutPutModel<FilterContactUsViewModel>> FilterAsync(FilterContactUsViewModel model);


    Task SaveAsync();

    Task<OutPutModel<ContactUsDetailsViewModel>> GetByIdAsync(int id);

    Task<OutPutModel<bool>> AnswerAsync(ContactUsDetailsViewModel model);
    


}
