using Microsoft.AspNetCore.Mvc;
using LoanApp.Models;
using LoanApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanApp.Controllers
{
    public class LoansController : Controller
    {
        private readonly IRepository<Loan> _loanRepository;
        private readonly IRepository<User> _userRepository;

        public LoansController(IRepository<Loan> repo, IRepository<User> userRepo)
        {
            this._loanRepository = repo;
            this._userRepository = userRepo;
        }
  
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
    
        public IActionResult AddLoan()
        {
            List<User> availableUsers = this._userRepository.GetAll().ToList();
            ViewBag.AvailableUsers = new SelectList(availableUsers, "UserId", "Name");
            return View("Create");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLoan(Loan model)
        {
            User signedUser = await this._userRepository.GetByCondition(u => u.Phone == User.Identity.Name);
            Loan newLoan = new Loan { UserId = signedUser.UserId, Value = model.Value, Reason = model.Reason, DateOfCreation = DateTime.Now, WhomUserId = model.WhomUserId };
            await this._loanRepository.Add(newLoan);
            User newUser = (User)signedUser.Clone();
            newUser.TotalLoan += model.Value;

            await this._userRepository.Update(newUser, signedUser);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
