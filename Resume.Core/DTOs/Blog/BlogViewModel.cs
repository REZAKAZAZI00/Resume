namespace Resume.Core.DTOs.Blog;
public class BlogViewModel
{
    public  int BlogId { get; set; }
    public string UserName { get; set; }

    public string? CategoryTitle { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public string PictureName { get; set; }

    public string Tags { get; set; }
    public int ViewCount { get; set; }

    public DateTime CreateDate { get; set; }

    public List<CommentViewModel>? Comments { get; set; }
}
