using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.DTO;
using E_Commers.Core.Entities;
using E_Commers.Core.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Application.InterFaces
{
    public interface IUserUseCase
    {

        Task<IdentityResult> CreateUser(RegisterUserDTO registerUserDto);
        IQueryable<ApplicationUserIdentity> GetAllUsers();
        Task<UpdateUserEntity> UpdateUserByName(string userName, RegisterUserDTO registerUserDto);
    }
}
