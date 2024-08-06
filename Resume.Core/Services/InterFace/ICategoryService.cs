namespace Resume.Core.Services.InterFace;
public interface ICategoryService
{

    Task<OutPutModel<bool>> CreateAsync(CreateCategoryViewModel model);
    Task<OutPutModel<bool>> UpdateAsync(UpdateCategoryViewModel model);
    Task<OutPutModel<bool>> DeleteAsync(DeleteCategoryViewModel model);
    Task<FilterCategoryViewModel> FilterAsync(FilterCategoryViewModel model);

    Task<DeleteCategoryViewModel> GetForDeleteByIdAsync(int id);
    Task<UpdateCategoryViewModel> GetForUpdateByIdAsync(int id);

    

}
