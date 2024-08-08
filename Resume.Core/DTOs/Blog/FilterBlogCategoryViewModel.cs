namespace Resume.Core.DTOs.Blog;
public class FilterBlogCategoryViewModel:BasePaging<BlogCategoryDetailsViewModel>
{

    [Display(Name = "Title")]
    public string? Title { get; set; }

    
}
