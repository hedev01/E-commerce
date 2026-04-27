using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_Commers.Core.Interfaces
{
    public interface  IAccountRepository
    {
        Task<IdentityResult> RegisterUser(RegisterUserDTO registerUserDTO);
    
    }
}
