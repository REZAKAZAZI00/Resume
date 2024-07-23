namespace Resume.Core.DTOs.User;

public class UserInfoViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]


    public string FirstName { get; set; }

    [Display(Name = "نام خانوداگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]


    public string LastName { get; set; }



    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
    [MaxLength(250, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

    public string Email { get; set; }

    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

    public string Phone { get; set; }


    [Display(Name = "فعال است؟")]

    public bool IaActive { get; set; }

    [Display(Name = "BirthDate")]

    public DateTime BirthDate { get; set; }

    public DateTime CreateDate { get; set; }

    public string? Bio { get; set; }

    public string? Location { get; set; }

    public string? PictureName { get; set; }
}
