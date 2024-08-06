namespace Resume.Core.Services.InterFace;

public interface ISkillsService
{

    Task<List<SkillsInfoViewModel>> GetSkillsInfoShowInHomeAsync();

    Task<FilterSkillsViewModel> FilterAsync(FilterSkillsViewModel model);

    Task<OutPutModel<bool>> CreateAsync(CreateSkillsViewModel model);
    Task<OutPutModel<bool>> UpdateAsync(UpdateSkillsViewModel model);
    Task<OutPutModel<bool>> DeleteAsync(DeleteSkillsViewModel model);
    Task<DeleteSkillsViewModel> GetForDeleteAsync(int id);
    Task<UpdateSkillsViewModel> GetSkillByIdAsync(int id);


}
