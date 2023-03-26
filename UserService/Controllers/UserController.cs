using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entity;
using Repository.Interface;
using System.Net;

namespace UserService.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        public readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var isEmailRegisted = _userRepo.IsUserEmailExisted(user.Email);

            if (isEmailRegisted)
            {
                return BadRequest("Email is already registed");
            }

            var isPhoneNumberUsed = _userRepo.IsUserPhoneNumberUsed(user.PhoneNumber);

            if (isPhoneNumberUsed)
            {
                return BadRequest("Phone Number is already used");
            }

            var newUser = await _userRepo.AddUser(user);
         
            if(newUser != null)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
