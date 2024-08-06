﻿namespace Resume.Core.DTOs.Category;

public class CreateCategoryViewModel
{
    [Display(Name = "Title")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(150, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Title { get; set; }

    [Display(Name = "Description")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Description { get; set; }

}
