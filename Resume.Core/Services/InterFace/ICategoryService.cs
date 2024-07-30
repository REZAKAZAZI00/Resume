namespace Resume.Core.Services.InterFace;
public interface ICategoryService
{

    Task<OutPutModel<bool>> CreateAsync(CreateCategoryViewModel model);
    Task<OutPutModel<bool>> UpdateAsync(UpdateCategoryViewModel model);
    Task<FilterCategoryViewModel> FilterAsync(FilterCategoryViewModel model);



}
