namespace Resume.Core.DTOs.Education;
public class CreateEducationViewModel
{

    [Display(Name = "InstitutionName")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string InstitutionName { get; set; }


    [Display(Name = "Description")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string? Description { get; set; }

    [Display(Name = "Degree")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Degree { get; set; }

    [Display(Name = "FieldOfStudy")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string FieldOfStudy { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }


}
