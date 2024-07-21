
namespace Resume.Core.Services.InterFace;

public interface IContactUsService
{

    Task<OutPutModel<bool>> CreateAysnc(CreateContactUsViewModel model); 

    Task<OutPutModel<FilterContactUsViewModel>> FilterAysnc(FilterContactUsViewModel model);



}
