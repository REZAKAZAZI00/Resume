namespace Resume.Core.DTOs.WorkExperiences;
public class FilterWorkExperiencesViewModel:BasePaging<WorkExperiencesDetailViewModel>
{
    public string? JobTitle { get; set; }

}
