namespace Resume.Core.DTOs.AboutMe;
public class AdminSideEditAboutMeViewModel
{
    
    public int Id { get; set; }

    [Display(Name = "Bio")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string? Bio { get; set; }

    [Display(Name = "Position")]
    [MaxLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string? Position { get; set; }


    [Display(Name = "Location")]
    [MaxLength(100, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string? Location { get; set; }

    [Display(Name = "ImageName")]
    public string? ImageName { get; set; }

    [Display(Name = "Avatar")]
    public IFormFile? Avatar { get; set; }

}
