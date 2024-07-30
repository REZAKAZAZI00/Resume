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
                Message = ""
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return new OutPutModel<bool>
            {
                Message = ex.Message,
                StatusCode = 500,
                Result = false,
            };

        }
    }

    public Task<FilterCategoryViewModel> FilterAsync(FilterCategoryViewModel model)
    {
        throw new NotImplementedException();
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
                    Message = ""
                };

            category.Description = model.Description;
            category.Title = model.Title;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return new OutPutModel<bool>
            {
                StatusCode = 200,
                Result = true,
                Message = ""
            };
        }
        catch (Exception ex)
        {

            return new OutPutModel<bool>
            {
                Message = ex.Message,
                StatusCode = 500,
                Result = false,
            };
        }
    }
    #endregion

}
