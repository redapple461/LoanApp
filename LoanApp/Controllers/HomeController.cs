using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.Repositories;

namespace LoanApp.Controllers
{
    public class HomeController  : Controller
    {
        private readonly IRepository<Loan> _loanRepository;

        public  HomeController(IRepository<Loan> repo)
        {
            this._loanRepository = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(this._loanRepository.GetAll());
        }
    }
}
