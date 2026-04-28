using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Application.InterFaces
{
    public interface  IRoleUseCase
    {
        Task<bool> CreateRole(string roleName);
        IQueryable<IdentityRole> getAllRoles();

        Task<IdentityResult> DeleteRoleById(string roleName);
        Task<IdentityResult> UpdateRoleById(string roleName, string newRoleName);

    }
}
