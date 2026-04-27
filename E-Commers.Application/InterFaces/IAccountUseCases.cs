using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.DTO;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Application.InterFaces
{
    public interface IAccountUseCases
    {
        Task<(string token, DateTime? expiryDate, string errorMessage)> LoginUser(LoginUserDTO loginUserDto);
        Task<IdentityResult> RegisterUser(RegisterUserDTO registerUserDto);
    }
}
