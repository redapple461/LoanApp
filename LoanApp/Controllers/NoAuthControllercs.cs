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

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string name, string phone, string password)
        {
            User newUser = new User { Name = name, Phone = phone, Password = password , ContactList = ""};
            db.Users.Add(newUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home", new {area = ""});
        }
    }
}
