using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commers.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> CreateRole(string roleName);
    }
}
