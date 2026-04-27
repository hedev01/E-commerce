using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace E_Commers.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> CreateRole(string roleName);
        IQueryable<IdentityRole> GetAllRoles();
        Task<IdentityResult> DeleteRoleById(string roleName);

    }
}
