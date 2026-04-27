using E_Commers.Application.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleUseCase _roleUseCase;

        public RoleController(IRoleUseCase roleUseCase)
        {
            _roleUseCase = roleUseCase;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            bool result = await _roleUseCase.CreateRole(roleName);
            if (result)
            {
                return Ok("Role Created");

            }
            else
            {
                return BadRequest("Not Created Role");
            }
        }
    }
}
