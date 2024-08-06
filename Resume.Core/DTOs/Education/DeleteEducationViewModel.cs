namespace Resume.Core.DTOs.Education;
public class DeleteEducationViewModel
{
    [Required(ErrorMessage = "Please enter {0}")]
    public int EducationId { get; set; }

    [Display(Name = "InstitutionName")]
    public string InstitutionName { get; set; }
}
