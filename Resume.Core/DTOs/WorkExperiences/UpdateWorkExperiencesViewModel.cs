namespace Resume.Core.DTOs.WorkExperiences;

public class UpdateWorkExperiencesViewModel
{

    [Display(Name = "ExperiencesId")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int WE_Id { get; set; }

    public string JobTitle { get; set; }

    public string CompanyName { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
