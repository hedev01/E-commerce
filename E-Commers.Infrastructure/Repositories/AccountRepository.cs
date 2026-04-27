using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.DTO;
using E_Commers.Core.Identity;
using E_Commers.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

namespace E_Commers.Infrastructure.Repositories
{
    public class AccountRepository(UserManager<ApplicationUserIdentity> userManager) : IAccountRepository
    {

        public async Task<IdentityResult> RegisterUser(RegisterUserDTO registerUserDTO)
        {


            var user = new ApplicationUserIdentity()
            {
                UserName = registerUserDTO.UserName,
                Email = registerUserDTO.Email
            };

            var result = await userManager.CreateAsync(user, registerUserDTO.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
            return result;


        }
      
        

    }
}
