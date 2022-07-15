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

        public  HomeController(IRepository<Loan> repo)
        {
            this._loanRepository = repo;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(this._loanRepository.GetAll());
        }
    }
}
