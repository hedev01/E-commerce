using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Application.InterFaces;
using E_Commers.Core.Entities;
using E_Commers.Infrastructure.Services;

namespace E_Commers.Application.UseCases
{
    public class JwtUseCase : IJwtUseCase
    {
        private readonly IJwtTokenService _jwtTokenService;
        public JwtUseCase(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public JwtEntity DecodeJwtToken(string jwtToken)
        {
            return _jwtTokenService.DecodeJwtToken(jwtToken);
        }
    }
}
