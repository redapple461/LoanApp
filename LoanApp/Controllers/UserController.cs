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
    }
}
