using System.ComponentModel.DataAnnotations.Schema;

namespace Resume.DataLayer.Entities.Project;

public class Project:BaseEntity<int>
{
    #region Property

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string PictureName { get; set; }


    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public  string? DeepLink { get; set; }
    public bool IsDelete { get; set; }

    #endregion


    #region Relations

    public virtual Category? Category { get; set; }
    #endregion

}
