namespace Resume.Core.DTOs.Category;

public  class CreateCategoryViewModel
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }

}
