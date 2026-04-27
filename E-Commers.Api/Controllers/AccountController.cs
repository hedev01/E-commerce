using E_Commers.Application.InterFaces;
using E_Commers.Application.Writes;
using E_Commers.Core.DTO;
using E_Commers.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountUseCases _accountUseCases;
        public AccountController(IAccountUseCases accountUseCases /*, UserManager<ApplicationUserIdentity> userManager*/)
        {
            _accountUseCases = accountUseCases;
            // _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDto)
        {
            

            var result = await _accountUseCases.RegisterUser(registerUserDto);

            if (result.Succeeded)
            {
                return Ok(new { Message = "ثبت نام با موفقیت انجام شد." });
            }
            else
            {
                
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Message = "خطا در ثبت نام", Errors = errors });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDto)
        {
            var (token, expiryDate, errorMessage) = await _accountUseCases.LoginUser(loginUserDto);

            if (errorMessage is not null)
            {
                return Unauthorized(new { Message = errorMessage }); // 401 Unauthorized
            }

            return Ok(new
            {
                Token = token,
                Expires = expiryDate
            });
        }
    }
}

