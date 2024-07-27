namespace Resume.Core.DTOs.Category;

public class FilterCategoryViewModel:BasePaging<CategoryDetailsViewModel>
{
    public string? Title { get; set; }

    public string? Description { get; set; }
}

