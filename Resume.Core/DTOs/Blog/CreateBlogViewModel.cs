namespace Resume.Core.DTOs.Blog;
public class CreateBlogViewModel
{
    
    public int CategoryId { get; set; }
    [Display(Name = "Title")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Title { get; set; }
    public string Description { get; set; }
   
    [Required(ErrorMessage = "Please enter {0}")]
    public string Tags { get; set; }
    
    public IFormFile? Image { get; set; }

}
