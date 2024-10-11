namespace Resume.Core.DTOs.Comment;
public class CommentViewModel
{
    public int CommentId { get; set; }

    public string CommentText { get; set; }

    public string Topic { get; set; }

    public DateTime CreateDate { get; set; }
}
