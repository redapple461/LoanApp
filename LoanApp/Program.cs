using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resoucres");
builder.Services.AddControllersWithViews().AddViewLocalization();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/SignIn");
        });

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection), ServiceLifetime.Transient);

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Loan>, LoanRepository>();

var app = builder.Build();

var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("ru")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("ru"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "signUp",
    pattern: "{controller}/{action}"
);

app.MapControllerRoute(
    name: "loans",
    pattern: "{controller=Loans}/{action=AddLoan}"
);

app.MapControllerRoute(
    name: "userProfile",
    pattern: "{controller=User}/{action=Profile}"
);

app.MapControllerRoute(
    name: "search",
    pattern: "{controller=User}/{action=Search}"
);

app.Run();
