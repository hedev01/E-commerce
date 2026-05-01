using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Entities;

namespace E_Commers.Application.InterFaces
{
    public interface IJwtUseCase
    {
        JwtEntity DecodeJwtToken(string jwtToken);
    }
}
