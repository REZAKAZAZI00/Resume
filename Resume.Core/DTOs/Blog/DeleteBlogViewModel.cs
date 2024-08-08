namespace Resume.Core.DTOs.Blog;
public class DeleteBlogViewModel
{
    [Display(Name ="Id")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int BlogId { get; set; }


    [Display(Name ="Title")]
    public string Title { get; set; }

}
