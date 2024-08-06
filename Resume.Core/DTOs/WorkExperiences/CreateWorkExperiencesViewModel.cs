namespace Resume.Core.DTOs.WorkExperiences;

public class CreateWorkExperiencesViewModel
{
    [Display(Name ="Title")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string JobTitle { get; set; }

    public string CompanyName { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
