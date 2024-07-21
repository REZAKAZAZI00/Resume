namespace Resume.Core.DTOs.ContactUs;
public class FilterContactUsViewModel:BasePaging<ContactUsDetailsViewModel>
{
    [Display(Name = "Email")]
    public string? Email { get; set; }

    [Display(Name = "Phone")]
    public string? Phone { get; set; }

    [Display(Name ="Title")]
    public string? Title { get; set; }

    [Display(Name = "FirstName")]
    public string? FirstName { get; set; }

    [Display(Name = "LastName")]
    public string? LastName { get; set; }

    [Display(Name = "AnswerStatus")]

    public FilterContactUsAnswerStatus AnswerStatus { get; set; }
}

public enum FilterContactUsAnswerStatus
{
    [Display(Name = "All")]

    All,
    [Display(Name = "Answered")]

    Answered,
    [Display(Name = "NotAnswered")]
    NotAnswered

}
