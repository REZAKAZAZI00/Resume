
namespace Resume.DataLayer.Entities.User;

public class User : BaseEntity<int>
{
    #region Properties

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public bool IaActive { get; set; }

    public DateTime BirthDate { get; set; }


    #endregion


}
