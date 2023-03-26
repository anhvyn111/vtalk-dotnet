using AutoMapper;
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
        public IMapper _mapper;

        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetUserByPhoneNumber(string phoneNumber)
        //{
        //    var user = await _userRepo.GetByPhoneNumber(phoneNumber);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetUserByEmail(string email)
        //{
        //    var user = await _userRepo.GetByEmail(email);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

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
