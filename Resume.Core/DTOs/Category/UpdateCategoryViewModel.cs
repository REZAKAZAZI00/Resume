namespace Resume.Core.DTOs.Category;

public class UpdateCategoryViewModel
{
    [Display(Name ="CategoryId")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int CategoryId { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Title { get; set; }

    [Display(Name = "Description")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Description { get; set; }
    public IFormFile? Image { get; set; }

    public string PictureName { get; set; }
}
