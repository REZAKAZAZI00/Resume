namespace Resume.Core.DTOs.Blog;
public class BlogCategoryDetailsViewModel
{

    [Display(Name = "CategoryId")]
    public int CategoryId { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(150, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Title { get; set; }

    [Display(Name = "Description")]
    [MaxLength(150, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Description { get; set; }

    public string PictureName { get; set; }

}
