using Microsoft.AspNetCore.Mvc;
using LoanApp.Models;
using LoanApp.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LoanApp.Controllers
{
    public class LoansController : Controller
    {
        private readonly IRepository<Loan> _loanRepository;

        public LoansController(IRepository<Loan> repo)
        {
            this._loanRepository = repo;
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
        [Authorize]
        public async Task<IActionResult> AddLoan(double value, string reason)
        {
            // TODO: Move from hardcode userId to real one
            Loan newLoan = new Loan { UserId = 1, Value = value, Reason = reason };
            this._loanRepository.Add(newLoan);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
