var builder = WebApplication.CreateBuilder(args);
#region Log
Log.Logger = new LoggerConfiguration()
   .MinimumLevel.Debug()
   .WriteTo.Console()
   .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
   .CreateLogger();
#endregion
builder.Host.UseSerilog();
// Add services to the container.
#region IOC
builder.Services.RegisterServices();
#endregion


#region DbContext
var connectionString = builder.Configuration.GetConnectionString("ResumeConnection");
builder.Services.AddDbContext<ResumeDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme=CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme=CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options=>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
});

#endregion
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
