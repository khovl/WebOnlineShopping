using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using WebOnlineShopping.Models;

var builder = WebApplication.CreateBuilder(args); 
   
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddNotyf(Config => { Config.DurationInSeconds = 3; Config.IsDismissable = true; Config.Position = NotyfPosition.TopRight; });
builder.Services.AddDbContext<MinimartDBContext>(option =>option.UseSqlServer(builder.Configuration.GetConnectionString("WebOnlineShopping")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapControllerRoute(    
name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); ;

app.Run();
