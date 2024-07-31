namespace Resume.Core.DTOs.Skills;
public class SkillsDetailsViewModel
{
    public int SkillId { get; set; }
    [Display(Name = "SkillName")]
    public string SkillName { get; set; }

    public int SkillLevel { get; set; }
}
