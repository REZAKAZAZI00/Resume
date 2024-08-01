namespace Resume.Core.DTOs.Skills;
public class CreateSkillsViewModel
{
    [Display(Name = "SkillName")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Name { get; set; }

    [Display(Name = "Level")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int Level { get; set; }
}
