namespace Resume.Core.DTOs.Category;

public class UpdateCategoryViewModel
{
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
}
