using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Application.InterFaces;
using E_Commers.Core.Interfaces;

namespace E_Commers.Application.UseCases
{
    public class RoleUseCase : IRoleUseCase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleUseCase(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<bool> CreateRole(string roleName)
        {
           return await _roleRepository.CreateRole(roleName);
        }
    }
}
