namespace Resume.DataLayer.Entities.Blog;
public class CategoryBlog:BaseEntity<int>
{


    #region Property

    public string Title { get; set; }
    public string Description { get; set; }

    public bool IsDelete { get; set; } = false;

    #endregion

    #region Relations

    public virtual List<Blog>? Blogs { get; set; }

    #endregion


}
