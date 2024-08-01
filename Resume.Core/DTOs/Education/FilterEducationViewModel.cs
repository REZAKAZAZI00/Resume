namespace Resume.Core.DTOs.Education;
public class FilterEducationViewModel:BasePaging<EducationDetailViewModel>
{
    public string? InstitutionName { get; set; }

    public string? Degree { get; set; }

}
