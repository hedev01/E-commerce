using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Identity;
using E_Commers.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Infrastructure.Repositories
{
    public class RoleRepository(RoleManager<IdentityRole> roleManager) : IRoleRepository
    {
        public async Task<bool> CreateRole(string roleName)
        {
            bool Exists = await roleManager.RoleExistsAsync(roleName);
            if (!Exists)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole() { Name = roleName });
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
