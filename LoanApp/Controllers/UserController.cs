using Microsoft.AspNetCore.Mvc;
using LoanApp.Repositories;
using LoanApp.Models;

namespace LoanApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;
        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActionResult> Profile()
        {
            return View(await this._userRepository.GetById(1));
        }
    }
}
