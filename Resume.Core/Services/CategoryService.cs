﻿using SixLabors.ImageSharp;

namespace Resume.Core.Services;
public class CategoryService : ICategoryService
{
    #region Fields

    private readonly ResumeDbContext _context;

    private readonly ILogger<CategoryService> _logger;
    #endregion

    #region Constructor
    public CategoryService(ResumeDbContext context, ILogger<CategoryService> logger)
    {
        _context = context;
        _logger = logger;
    }


    #endregion

    #region Methods


    public async Task<OutPutModel<bool>> CreateAsync(CreateCategoryViewModel model)
    {
        try
        {
            string imageName = "Default.png";
            if (model.Image is not null)
            {
                if (model.Image.IsImage())
                {
                    imageName = NameGenerator.GenerateNameForImage(15) + Path.GetExtension(model.Image.FileName);
                    model.Image.AddImageToServer(fileName: imageName,
                        SiteTools.ImageCategories,
                        thumbPath: SiteTools.ImageCategoriesThumb,
                        width: 150, height: 100);

                }
                else
                {

                    return new OutPutModel<bool>
                    {
                        StatusCode = 400,
                        Result = false,
                        Message = "The uploaded file is not an image. Please upload a file with one of : .jpg, .jpeg, .png"

                    };
                }
            }
            var newCategory = new Category
            {
                Description = model.Description,
                IsDelete = false,
                CreateDate = DateTime.Now,  
                 PictureName = imageName,
                Title = model.Title,
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Result = true,
                Message = "Added SuccessFully."
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                Message = "Unexpected error. Please try again.",
                StatusCode = 500,
                Result = false,
            };

        }
    }

    public async Task<OutPutModel<bool>> DeleteAsync(DeleteCategoryViewModel model)
    {
        try
        {
            var category = await _context.Categories.FindAsync(model.CategoryId);
            if (category is null)
                return new OutPutModel<bool>
                {
                    StatusCode = 404,
                    Message = "Not Found Category.",
                    Result = false,
                };
            category.IsDelete = true;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                Result = true,
                StatusCode = 200,
                Message = "Deleted SuccessFully."
            };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                StatusCode = 500,
                Result = false,
                Message = "Unexpected error. Please try again.",

            };
        }
    }

    public async Task<FilterCategoryViewModel> FilterAsync(FilterCategoryViewModel model)
    {
        try
        {
            var query = _context.Categories
                .AsNoTracking()
                .AsQueryable();
            string title = $"%{model.Title}%";
            if (!string.IsNullOrEmpty(model.Title))
                query = query.Where(s => EF.Functions.Like(s.Title, title));


            await model.Paging(query
                .Select(c => new CategoryDetailsViewModel
                {
                    Title = c.Title,
                    CategoryId = c.Id,
                    PictureName = c.PictureName,
                    Description = c.Description,
                }));

            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<DeleteCategoryViewModel> GetForDeleteByIdAsync(int id)
    {
        try
        {
            var category = await _context.Categories.
                 Where(c => c.Id == id)
                 .Select(c => new DeleteCategoryViewModel
                 {
                     CategoryId = c.Id,
                     Title = c.Title,
                 })
                 .SingleOrDefaultAsync();

            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;

        }
    }

    public async Task<UpdateCategoryViewModel> GetForUpdateByIdAsync(int id)
    {
        try
        {
            var category = await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new UpdateCategoryViewModel
                {
                    CategoryId = c.Id,
                    Description = c.Description,
                    Title = c.Title,
                    PictureName = c.PictureName,
                })
                .SingleOrDefaultAsync();

            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<List<CategoryDetailsViewModel>> GetCategoriesForShowHomeAsync(int pageId=1, int take=5)
    {
        try
        {
            int skip=(pageId - 1);
           var category=await _context.Categories
                .AsNoTracking()
                .Select(c=> new CategoryDetailsViewModel
                {
                     Title=c.Title,
                     PictureName=c.PictureName,
                })
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return null;
        }
    }

    public async Task<OutPutModel<bool>> UpdateAsync(UpdateCategoryViewModel model)
    {
        try
        {
            var category = await _context.Categories.FindAsync(model.CategoryId);

            if (category is null)
                return new OutPutModel<bool>
                {
                    StatusCode = 404,
                    Result = false,
                    Message = "Not Found Category."
                };

            if (model.Image is not null)
            {
                if (model.Image.IsImage())
                {
                    if (category.PictureName != "Default.png")
                    {
                       category.PictureName.DeleteImage(SiteTools.ImageCategories, SiteTools.ImageCategoriesThumb);
                    }
                    category.PictureName = NameGenerator.GenerateNameForImage(15) + Path.GetExtension(model.Image.FileName);
                    model.Image.AddImageToServer(fileName: category.PictureName,
                                            SiteTools.ImageCategories,
                                            thumbPath: SiteTools.ImageCategoriesThumb,
                                            width: 150, height: 100);
                }
                else
                {

                    return new OutPutModel<bool>
                    {
                        StatusCode = 400,
                        Result = false,
                        Message = "The uploaded file is not an image. Please upload a file with one of : .jpg, .jpeg, .png"

                    };
                }
            }

            category.Description = model.Description;
            category.Title = model.Title;
          
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Result = true,
                Message = "Updated SuccessFully."
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                Message = "Unexpected error. Please try again.",
                StatusCode = 500,
                Result = false,
            };
        }
    }
    #endregion

}
