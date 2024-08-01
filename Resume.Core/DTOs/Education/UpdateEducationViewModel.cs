namespace Resume.Core.DTOs.Education;

public class UpdateEducationViewModel
{
    [Required(ErrorMessage = "Please enter {0}")]
    public int EducationId { get; set; }

    [Display(Name = "InstitutionName")]
    public string InstitutionName { get; set; }


    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "Degree")]
    public string Degree { get; set; }

    [Display(Name = "FieldOfStudy")]
    public string FieldOfStudy { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

}
