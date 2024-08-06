namespace Resume.Core.DTOs.Category;

public class FilterCategoryViewModel:BasePaging<CategoryDetailsViewModel>
{
    [Display(Name ="Title")]
    public string? Title { get; set; }

   
}

