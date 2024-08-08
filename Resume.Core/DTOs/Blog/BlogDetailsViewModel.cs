namespace Resume.Core.DTOs.Blog;
public class BlogDetailsViewModel
{

    public int BlogId { get; set; }
    public int? UserId { get; set; }
    public string? UserName { get; set; }

    public int? CategoryId { get; set; }
    public  string? CategoryTitle { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }

    public string PictureName { get; set; }

    public string Tags { get; set; }
    public int ViewCount { get; set; }
}
