using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/SignIn");
        });

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Loan>, LoanRepository>();

var app = builder.Build();

app.UseDeveloperExceptionPage();

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

app.Run();
