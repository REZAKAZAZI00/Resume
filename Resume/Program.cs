using Microsoft.EntityFrameworkCore;
using Resume.DataLayer.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
#region Log
Log.Logger = new LoggerConfiguration()
   .MinimumLevel.Debug()
   .WriteTo.Console()
   .WriteTo.File("data/log.txt", rollingInterval: RollingInterval.Day)
   .CreateLogger();
#endregion
builder.Host.UseSerilog();
// Add services to the container.
#region IOC

#endregion

#region DbContext
var connectionString = builder.Configuration.GetConnectionString("ResumeConnection");
builder.Services.AddDbContext<ResumeDbContext>(options=>options.UseSqlServer(connectionString));
#endregion

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
