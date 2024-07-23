namespace Resume.DataLayer.Entities.Skills;

public  class Skills:BaseEntity<int>
{
    public int UserId { get; set; }

    public string SkillName { get; set; }

    public int SkillLevel { get; set; }


    #region Relations

    public virtual User.User? User { get; set; }
    #endregion
}
