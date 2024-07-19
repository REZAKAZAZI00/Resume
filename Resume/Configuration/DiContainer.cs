

namespace Resume.Web.Configuration;

public static class DiContainer
{

    public static void RegisterServices(this IServiceCollection service)
    {
        #region Services

        service.AddScoped<IUserService, UserService>();

        #endregion

    }
}
