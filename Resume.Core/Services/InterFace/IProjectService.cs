namespace Resume.Core.Services.InterFace;
public interface IProjectService
{

    Task<List<SelectListItem>> GetCategoryForManageProduct();
     
    Task<OutPutModel<bool>>  DeleteAsync(int id);
    Task<OutPutModel<bool>>  CreateAsync(CreateProjectViewModel model);
    Task<OutPutModel<bool>>  UpdateAsync(UpdateProjectViewModel model);

    Task<FilterProjectViewModel>  FilterAsync(FilterProjectViewModel model);
    

}
