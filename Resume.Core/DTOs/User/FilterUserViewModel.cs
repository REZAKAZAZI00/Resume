
namespace Resume.Core.DTOs.User;
public class FilterUserViewModel:BasePaging<UserDetailsViewModel>
{

    [Display(Name = "Email")]
    public string? Email { get; set; }


    [Display(Name = "PhoneNumber")]
    public string? Phone { get; set; }
}
