using E_Commers.Application.InterFaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            IQueryable<IdentityRole> result = _roleUseCase.getAllRoles();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            IdentityResult result = await _roleUseCase.DeleteRoleById(roleName);
            if (result.Succeeded)
            {
                return Ok("Role Deleted");
            }
            else
            {

                return BadRequest(result.Errors);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(string roleName, string newRoleName)
        {
           IdentityResult result  = await _roleUseCase.UpdateRoleById(roleName, newRoleName);
           if (result.Succeeded)
           {
               return Ok("Updated Role");

           }
           else
           {
               return BadRequest(result.Errors);
           }
        }
    }
}
