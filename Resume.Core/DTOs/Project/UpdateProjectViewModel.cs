﻿namespace Resume.Core.DTOs.Project;
public class UpdateProjectViewModel
{
    [Display(Name = "Id")]
    [Required(ErrorMessage = "Please enter {0}")]
    public int ProjectId { get; set; }

    public string? CategoryTitle { get; set; }

    public int CategoryId { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    public IFormFile? Image { get; set; }
    public string PictureName { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public string? DeepLink { get; set; }
    public bool IsDelete { get; set; }

}
