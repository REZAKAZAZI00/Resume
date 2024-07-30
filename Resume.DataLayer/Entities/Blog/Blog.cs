namespace Resume.DataLayer.Entities.Blog;
public class Blog:BaseEntity<int>
{
    #region Property

    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public string PictureName { get; set; }

    public string Tags { get; set; }
    public int ViewCount { get; set; }

    #endregion

    #region Relations

    public virtual CategoryBlog? CategoryBlog { get; set; }

    public virtual User.User? User { get; set; }
    public virtual List<Comment>? Comments  { get; set; }


    #endregion
}
