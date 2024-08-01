
namespace Resume.Core.Services.InterFace;

public interface IEducationService
{
    Task<List<EducationDetailViewModel>> GetEducationsAsync();
    Task<OutPutModel<bool>> CreateAsync(CreateEducationViewModel model);
    Task<OutPutModel<bool>> UpdateAsync(UpdateEducationViewModel model);
    Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);
    Task DeleteAsync(int id);
    Task<UpdateEducationViewModel>  GetEducationForUpdateById(int id);
}
