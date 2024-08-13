namespace Resume.Core.Tools;

public class SiteTools
{


    #region DefaultNames

    public static string DefaultImageName { get; set; }

    #endregion

    #region About me

    public static string AboutMeAvatar { get; set; } = "/img/UserProfile/";

    #endregion

    #region Project

    public static string ImageProject { get; set; } = "/img/Project/";
    public static string ImageProjectthumb { get; set; } = "/img/Project/thumb/";


    #endregion

    #region Blog
    public static string Imageblog { get; set; } = "/img/blog/";
    public static string ImageBlogThumb { get; set; } = "/img/blog/thumb/";

    #endregion

    #region category
    public static string ImageCategories { get; set; } = "/img/categories/";
    public static string ImageCategoriesThumb { get; set; } = "/img/categories/thumb/";

    #endregion
}
