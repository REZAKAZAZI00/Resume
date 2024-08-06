namespace Resume.Core.DTOs.Skills;
public class DeleteSkillsViewModel
{
    [Display(Name = "SkillName")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int SkillsId { get; set; }

    [Display(Name = "SkillName")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Name { get; set; }
}
