using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Application.InterFaces;
using E_Commers.Application.Services;
using E_Commers.Core.DTO;
using E_Commers.Core.Identity;
using E_Commers.Core.Interfaces;
using E_Commers.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace E_Commers.Application.Writes
{

    public class AccountUseCases : IAccountUseCases
    {
        private readonly IAccountRepository _accountRepository; 
        private readonly UserManager<ApplicationUserIdentity> _userManager; 
        private readonly IJwtTokenService _jwtTokenService; 

        // Constructor Injection
        public AccountUseCases(IAccountRepository accountRepository, UserManager<ApplicationUserIdentity> userManager, IJwtTokenService jwtTokenService)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<IdentityResult> RegisterUser(RegisterUserDTO registerUserDto)
        {
            
            return await _accountRepository.RegisterUser(registerUserDto);
        }

        public async Task<(string token, DateTime? expiryDate, string errorMessage)> LoginUser(LoginUserDTO loginUserDto)
        {
            
            ApplicationUserIdentity userFromDB = await _userManager.FindByNameAsync(loginUserDto.UserName);
            if (userFromDB is null)
            {
                return (null, null, "نام کاربری یا رمز عبور اشتباه است.");
            }

            bool passwordIsValid = await _userManager.CheckPasswordAsync(userFromDB, loginUserDto.Password);
            if (!passwordIsValid)
            {
                return (null, null, "نام کاربری یا رمز عبور اشتباه است.");
            }

            
            var roles = await _userManager.GetRolesAsync(userFromDB);

            
            string token = _jwtTokenService.GenerateToken(userFromDB, roles);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            DateTime expiryDate = jwtToken.ValidTo;

            return (token, expiryDate, null); 
        }
    }
}
