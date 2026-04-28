using E_Commers.Application.InterFaces;
using E_Commers.Core.DTO;
using E_Commers.Core.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase _userUseCase;

        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }
        [HttpPost("")]
        [Authorize("Admin")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO registerUserDto)
        {
            var result = await _userUseCase.CreateUser(registerUserDto);
            if (result.Succeeded)
            {
                return Ok("ساخت کاربر با موفقیت انجام شد");
            }
            else
            {
                return BadRequest(result.Errors);

            }
        }
        [HttpGet]
        public IQueryable<ApplicationUserIdentity> GetAllUsers()
        {
            return _userUseCase.GetAllUsers();
        }
    }
}
