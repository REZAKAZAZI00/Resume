
namespace Resume.Core.DTOs.User;
public class FilterUserViewModel:BasePaging<UserDetailsViewModel>
{

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }


    [Display(Name = "شماره تلفن")]
    public string? Phone { get; set; }
}
