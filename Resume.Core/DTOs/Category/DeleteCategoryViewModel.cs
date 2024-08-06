namespace Resume.Core.DTOs.Category;
public class DeleteCategoryViewModel
{
    [Display(Name ="Id")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int CategoryId { get; set; }

    public string Title { get; set; }
}
