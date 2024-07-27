namespace Resume.Web.Configuration;
public static class DiContainer
{

    public static void RegisterServices(this IServiceCollection service)
    {
        #region Services

        service.AddScoped<IUserService, UserService>();
        service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        service.AddScoped<ITokenHelperService, TokenHelper>();
        service.AddScoped<IContactUsService, ContactUsService>();
        service.AddTransient<ISkillsService, SkillsService>();
        service.AddScoped<IEducationService, EducationService>();
        service.AddScoped<IWorkExperiencesService, WorkExperiencesService>();
        service.AddScoped<ICategoryService,CategoryService>();
        service.AddScoped<IProjectService,ProjectService>();
        service.AddScoped<IStatisticsService, StatisticsService>();

        #endregion

    }
}
