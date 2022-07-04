using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;

namespace LoanApp.Controllers
{
    public class NoAuth : Controller
    {
        ApplicationContext db;

        public NoAuth(ApplicationContext context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
