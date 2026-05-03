using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Application.InterFaces;
using E_Commers.Core.Entities;
using E_Commers.Core.Interfaces;
using E_Commers.Core.Model;

namespace E_Commers.Application.UseCases
{
    public class ProductUseCase : IProductUseCase
    {
        IProductRepository _repository;
        public ProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<ProductEntity>> AddProduct(ProductEntity entity)
        {
            return await _repository.AddProduct(entity);
        }

        public Result<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public async Task<Result<ProductEntity>> UpdateProduct(ProductEntity entity)
        {
            return await _repository.UpdateProduct(entity);
        }
    }
}
