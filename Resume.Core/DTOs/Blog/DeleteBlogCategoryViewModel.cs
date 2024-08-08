namespace Resume.Core.DTOs.Blog;
public class DeleteBlogCategoryViewModel
{
    [Display(Name ="CategoryId")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int CategoryId { get; set; }

    public string Title { get; set; }
}
