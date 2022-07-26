using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LoanApp.Controllers
{
    public class HomeController  : Controller
    {
        private readonly IRepository<Loan> _loanRepository;
        private readonly IRepository<User> _userRepository;

        public  HomeController(IRepository<Loan> repo, IRepository<User> userRepo)
        {
            this._loanRepository = repo;
            this._userRepository = userRepo;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            User signedUser = await this._userRepository.GetByCondition(u => u.Phone == User.Identity.Name);
            List<Loan> allUserLoan = this._loanRepository.GetRangeByCondition(l => l.UserId == signedUser.UserId).Result.ToList<Loan>();
            ViewBag.TotalLoan = signedUser.TotalLoan;
            return View("Index", allUserLoan);
        }
    }
}
