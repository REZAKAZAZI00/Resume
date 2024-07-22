namespace Resume.Core.DTOs.ContactUs;
public class ContactUsDetailsViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime CreateDate { get; set; }

    [Display(Name = "Answer")]
    [Required(ErrorMessage = "Please enter {0}")]
    public string Answer { get; set; }
}
