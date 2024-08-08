namespace Resume.Core.DTOs.Blog;
public class FilterBlogViewModel:BasePaging<BlogDetailsViewModel>
{

    [Display(Name ="Title")]
    public string? Title { get; set; }


}
