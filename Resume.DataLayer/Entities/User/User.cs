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

    #region Relations
    public virtual AboutMe.AboutMe? AboutMe { get; set; }

    public virtual  List<Skills.Skills>? Skills { get; set; }

    public virtual List<Education.Education>? Educations { get; set; }

    public virtual List<WorkExperiences.WorkExperiences>? WorkExperiences { get; set; }
    #endregion
}
