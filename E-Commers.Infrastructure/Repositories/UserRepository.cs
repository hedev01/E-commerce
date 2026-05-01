using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.DTO;
using E_Commers.Core.Entities;
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
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }


            return result;
        }

        public IQueryable<ApplicationUserIdentity> GetAllUsers()
        {
            IQueryable<ApplicationUserIdentity> users = userManager.Users;
            return users;
        }

        public async Task<UpdateUserEntity> UpdateUserByName(string userName, RegisterUserDTO registerUserDto)
        {
            var model = await userManager.FindByNameAsync(userName);

            if (model == null)
                return null;

            model.UserName = registerUserDto.UserName;
            model.Email = registerUserDto.Email;

            var updateResult = await userManager.UpdateAsync(model);

            if (!updateResult.Succeeded)
                return null;

           
            if (!string.IsNullOrEmpty(registerUserDto.Password))
            {
                await userManager.RemovePasswordAsync(model);
                await userManager.AddPasswordAsync(model, registerUserDto.Password);
            }

            return new UpdateUserEntity
            {
                oldUserName = userName,
                ApplicationUserIdentity = model
            };
        }
    }
}
