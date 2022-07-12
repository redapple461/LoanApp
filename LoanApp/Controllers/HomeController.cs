using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;

namespace LoanApp.Controllers
{
    public class HomeController  : Controller
    {
        ApplicationContext db;

        public  HomeController(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Loans.ToListAsync());
        }
    }
}
