using E_Commers.Application.InterFaces;
using E_Commers.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductUseCase _UseCase;

        public ProductController(IProductUseCase useCase)
        {
            _UseCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductEntity entity)
        {
           var result = await _UseCase.AddProduct(entity);
           return Ok(result);
        }
    }
}
