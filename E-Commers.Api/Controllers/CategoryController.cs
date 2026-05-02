using E_Commers.Application.InterFaces;
using E_Commers.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryUseCase _categoryUseCase;

        public CategoryController(ICategoryUseCase categoryUseCase)
        {
            _categoryUseCase = categoryUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryEntity category)
        {
            var result = await _categoryUseCase.AddCategory(category);
            if (result.IsSuccess.GetValueOrDefault())
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var result = _categoryUseCase.GetAllCategory();
            if (result.IsSuccess.GetValueOrDefault())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _categoryUseCase.GetCategoryById(id);
            if (result.IsSuccess.GetValueOrDefault())
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoryById(string name, int id)
        {
           var result =  await _categoryUseCase.UpdateCategoryById(name, id);
           if (result.IsSuccess.GetValueOrDefault())
           {

               return Ok(result);
           }
           else
           {
               return BadRequest(result.ErrorMessage);
           }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var result = await _categoryUseCase.DeleteCategoryById(id);
            if (result.IsSuccess.GetValueOrDefault())
            {
                return Ok("Remove Success");
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
    }
}
