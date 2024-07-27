namespace Resume.Core.DTOs.Project;
public class FilterProjectViewModel:BasePaging<ProjectDetailsViewModel>
{
    public int? CategoryId { get; set; }

    public string? Title { get; set; }

    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
