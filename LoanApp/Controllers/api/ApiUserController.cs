using Microsoft.AspNetCore.Mvc;
using LoanApp.Models;
using LoanApp.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace LoanApp.Controllers.api
{
    [ApiController]
    [Route("api/User")]
    public class ApiUserController
    {
        private readonly IRepository<User> _userRepository;
        public ApiUserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Authorize]
        public async void AddToContactList([FromBody] User user)
        {
            User signedUser = await this._userRepository.GetByCondition(u => u.Phone == "375292309343");
            this._userRepository.Update(user, signedUser);
        }
    }
}
