using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.DTO;
using E_Commers.Core.Identity;
using E_Commers.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Infrastructure.Repositories
{
    public class UserRepository(UserManager<ApplicationUserIdentity> userManager) : IUserRepository
    {
        public async Task<IdentityResult> CreateUser(RegisterUserDTO registerUserDto)
        {
            var user = new ApplicationUserIdentity()
            {
                UserName = registerUserDto.UserName,
                PasswordHash = registerUserDto.Password,
                Email = registerUserDto.Email,
            };
            var result = await userManager.CreateAsync(user);
            return result;
        }
    }
}
