using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Loan>, LoanRepository>();

var app = builder.Build();

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

app.Run();
