namespace Resume.Core.DTOs.Project;
public class ProjectDetailsViewModel
{

    public int ProjectId { get; set; }

    public string CategoryTitle { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string PictureName { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public string? DeepLink { get; set; }
    public bool IsDelete { get; set; }
}
