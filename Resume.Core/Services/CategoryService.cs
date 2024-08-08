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
            var newCategory = new Category
            {
                Description = model.Description,
                IsDelete = false,
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
