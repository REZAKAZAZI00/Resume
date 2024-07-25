namespace Resume.Core.DTOs.WorkExperiences;

public class WorkExperiencesDetailViewModel
{
   
    public string JobTitle { get; set; }

    public string CompanyName { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
