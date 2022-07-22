using Microsoft.AspNetCore.Mvc;
using LoanApp.Repositories;
using LoanApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace LoanApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;
        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        [Authorize]
        public async Task<ActionResult> Profile()
        {
            return View(await this._userRepository.GetByCondition(u => u.Phone == User.Identity.Name));
        }

        [HttpGet]
        public async Task<ActionResult> Search()
        {
            return View("Search", this._userRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Search(string phone)
        {
            return View("Search", this._userRepository.GetByCondition(user => user.Phone == phone));
        }
    }
}
