namespace Resume.Core.DTOs.Education;

public class UpdateEducationViewModel
{
    [Required(ErrorMessage = "Please enter {0}")]
    public int EducationId { get; set; }
    public string? InstitutionName { get; set; }
    public string? Description { get; set; }
    public string? Degree { get; set; }
    public string? FieldOfStudy { get; set; }

    [Required(ErrorMessage = "Please enter {0}")]
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
