using Microsoft.EntityFrameworkCore;
using LoanApp.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NoAuth}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "signUp",
    pattern: "{controller}/{action}"
);

app.Run();
