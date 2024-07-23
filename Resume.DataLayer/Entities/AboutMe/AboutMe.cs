namespace Resume.DataLayer.Entities.AboutMe;
public class AboutMe:BaseEntity<int>
{
    public int UserId { get; set; }

    public string? Bio { get; set; }

    public string? Location { get; set; }

    public string? PictureName { get; set; }

    #region Relations

    public virtual User.User?  User { get; set; }
    #endregion
}
