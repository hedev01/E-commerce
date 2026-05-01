using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Entities;
using E_Commers.Core.Identity;

namespace E_Commers.Infrastructure.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(ApplicationUserIdentity user, IList<string> roles);
        JwtEntity DecodeJwtToken(string  jwtToken);
    }
}
