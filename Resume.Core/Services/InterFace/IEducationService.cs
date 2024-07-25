
namespace Resume.Core.Services.InterFace;

public interface IEducationService
{
    Task<List<EducationDetailViewModel>> GetEducationsAsync();


    Task<OutPutModel<bool>> CreateEducationAsync(CreateEducationViewModel model);
    Task<OutPutModel<bool>> UpdateEducationAsync(UpdateEducationViewModel model);
}
