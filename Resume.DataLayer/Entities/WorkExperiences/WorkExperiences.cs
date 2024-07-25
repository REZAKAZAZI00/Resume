namespace Resume.DataLayer.Entities.WorkExperiences;

public class WorkExperiences:BaseEntity<int>
{
    #region Property


    public  int UserId { get; set; }
    public string JobTitle { get; set; }

    public string CompanyName { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

    #endregion


    public virtual User.User? User { get; set; }
    #region Relations

    #endregion
}
