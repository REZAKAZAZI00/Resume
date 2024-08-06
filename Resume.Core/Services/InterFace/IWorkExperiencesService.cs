namespace Resume.Core.Services.InterFace;
public interface IWorkExperiencesService
{
    Task<List<WorkExperiencesDetailViewModel>> GetWorkExperiencesAsync();
    Task<OutPutModel<bool>> CreateAsync(CreateWorkExperiencesViewModel model);
    Task<OutPutModel<bool>> UpdateAsync(UpdateWorkExperiencesViewModel model);
    Task<OutPutModel<bool>> DeleteAsync(DeleteWorkExperiencesViewModel model);
    Task<FilterWorkExperiencesViewModel> FilterAsync(FilterWorkExperiencesViewModel model);
    Task<UpdateWorkExperiencesViewModel> GetForUpdateAsync(int id);
    Task<DeleteWorkExperiencesViewModel> GetForDeleteAsync(int id);

}
