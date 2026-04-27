using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.DTO;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUser(RegisterUserDTO registerUserDto);
    }
}
