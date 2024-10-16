﻿namespace Resume.Core.Services.InterFace;
public interface IBlogService
{
    Task<List<SelectListItem>> GetCategoryForManageBlogAsync();
    Task<FilterBlogViewModel> FilterAsync(FilterBlogViewModel model);
    Task<OutPutModel<bool>> CreateAsync(CreateBlogViewModel model);
    Task<OutPutModel<bool>> UpdateAsync(UpdateBlogViewModel model);
    Task<OutPutModel<bool>> DeleteAsync(DeleteBlogViewModel model);

    Task<UpdateBlogViewModel> GetBlogForUpdateAsync(int  id);
    Task<DeleteBlogViewModel> GetBlogForDeleteAsync(int  id);

    Task<BlogViewModel> GetBlogByIdAsync(int id);
    Task<List<BlogViewModel>> GetPopularBlogsAsync(int pageId=1,int take=6);

    #region BlogCategory
    Task<FilterBlogCategoryViewModel> FilterAsync(FilterBlogCategoryViewModel model);
    Task<OutPutModel<bool>> CreateBlogCategoryAsync(CreateBlogCategoryViewModel model);
    Task<OutPutModel<bool>> UpdateBlogCategoryAsync(UpdateBlogCategoryViewModel model);
    Task<OutPutModel<bool>> DeleteBlogCategoryAsync(DeleteBlogCategoryViewModel model);

    Task<UpdateBlogCategoryViewModel> GetBlogCategoryForUpdateAsync(int id);
    Task<DeleteBlogCategoryViewModel> GetBlogCategoryForDeleteAsync(int id);

    Task<List<BlogCategoriesViewModel>> GetBlogCategoriesAsync();
    Task<List<BlogCategoriesViewModel>> GetBlogCategoriesAsync(int pageId = 1, int take =3);
    #endregion

}
