using E_Commers.Application.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        private readonly IJwtUseCase _jwtUseCase;

        public JwtController(IJwtUseCase jwtUseCase)
        {
            _jwtUseCase = jwtUseCase;
        }

        [HttpPost("DecodeJwtToken")]
        public IActionResult DecodeJwtToken([FromBody]string jwtToken)
        {
            var result = _jwtUseCase.DecodeJwtToken(jwtToken);
            if (string.IsNullOrEmpty(result.WarningMessage))
            {
                return Ok(result);
                
            }
            else
            {
                return BadRequest(result.WarningMessage);
            }
        }
    }
}
