namespace Resume.DataLayer.Entities.Blog;

public class Comment:BaseEntity<int>
{
    #region Property

    public int BlogId { get; set; }

    public int Reply { get; set; }

    public string FullName { get; set; }

    public string Emeil { get; set; }

    public string Topic { get; set; }

    public string Massage { get; set; }

    #endregion


    #region Relations

    public virtual Blog? Blog { get; set; }

    #endregion
}
