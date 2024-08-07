namespace Resume.Core.Services.InterFace;
public interface IProjectService
{

    Task<List<SelectListItem>> GetCategoryForManageProductAsync();
     
    Task<OutPutModel<bool>>  DeleteAsync(DeleteProjectViewModel model);
    Task<OutPutModel<bool>>  CreateAsync(CreateProjectViewModel model);
    Task<OutPutModel<bool>>  UpdateAsync(UpdateProjectViewModel model);

    Task<FilterProjectViewModel>  FilterAsync(FilterProjectViewModel model);


    Task<DeleteProjectViewModel> GetProjectForDeleteByIdAsync(int id);
    Task<UpdateProjectViewModel> GetProjectForUpdateByIdAsync(int id);

}
