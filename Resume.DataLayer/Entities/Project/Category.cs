namespace Resume.DataLayer.Entities.Project;

public class Category:BaseEntity<int>
{
    #region Property

    public  string Title { get; set; }
    public string Description { get; set; }

    public bool IsDelete { get; set; }


    #endregion

    #region Relations
    public virtual List<Project>? Projects { get; set; }
    #endregion
}
