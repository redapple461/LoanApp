using Microsoft.AspNetCore.Mvc;
using LoanApp.Models;

namespace LoanApp.Controllers
{
    public class LoansController : Controller
    {
        ApplicationContext db;

        public LoansController(ApplicationContext context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddLoan()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> AddLoan(double value, string reason)
        {
            Loan newUser = new Loan { UserId = 1, Value = value, Reason = reason };
            db.Loans.Add(newUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
