namespace Resume.Core.DTOs.WorkExperiences;
public class DeleteWorkExperiencesViewModel
{

    [Display(Name = "ExperiencesId")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int WE_Id { get; set; }

    public string JobTitle { get; set; }
}
