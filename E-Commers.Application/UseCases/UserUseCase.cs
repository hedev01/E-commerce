using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Application.InterFaces;
using E_Commers.Core.DTO;
using E_Commers.Core.Identity;
using E_Commers.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Application.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IdentityResult> CreateUser(RegisterUserDTO registerUserDto)
        {
            return await _userRepository.CreateUser(registerUserDto);
        }

        public IQueryable<ApplicationUserIdentity> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
