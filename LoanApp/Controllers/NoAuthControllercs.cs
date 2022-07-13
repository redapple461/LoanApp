using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.Repositories;

namespace LoanApp.Controllers
{
    public class NoAuth : Controller
    {
        private readonly IRepository<User> _userRepository;

        public NoAuth(IRepository<User> repo)
        {
            this._userRepository = repo;
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
            this._userRepository.Add(newUser);
            this._userRepository.SaveChanges();
            return RedirectToAction("Index", "Home", new {area = ""});
        }
    }
}
