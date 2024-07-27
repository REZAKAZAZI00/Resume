namespace Resume.Core.DTOs.Project;

public class CreateProjectViewModel
{
    [Required]
    public int CategoryId { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public string? PictureName { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public string? DeepLink { get; set; }

}
