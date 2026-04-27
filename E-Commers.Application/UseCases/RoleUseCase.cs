using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Application.InterFaces;
using E_Commers.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

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

        public IQueryable<IdentityRole> getAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public async Task<IdentityResult> DeleteRoleById(string roleName)
        {
            return await _roleRepository.DeleteRoleById(roleName);
        }
    }
}
