namespace Resume.Core.DTOs.ContactUs;

public class CreateContactUsViewModel
{
    [Display(Name = "Title")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(300, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Title { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(1000, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Description { get; set; }

    [Display(Name = "Phone Number")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(15, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string PhoneNumber { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Please enter {0}")]
    [MaxLength(150, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string FirstName { get; set; }


    [Display(Name = "Email")]
    [Required(ErrorMessage = "Please enter {0}")]
    [EmailAddress(ErrorMessage = "The entered email is not valid")]
    [MaxLength(250, ErrorMessage = "{0} cannot be more than {1} characters.")]
    public string Email { get; set; }


}
