namespace Resume.Core.DTOs.Project;
public class DeleteProjectViewModel
{

    [Display(Name = "Id")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int ProjectId { get; set; }

    [Display(Name ="Title")]
    public string Title { get; set; }
}
