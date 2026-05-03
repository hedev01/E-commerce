using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Entities;
using E_Commers.Core.Interfaces;
using E_Commers.Core.Model;
using E_Commers.Infrastructure.Data;

namespace E_Commers.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<Result<ProductEntity>> AddProduct(ProductEntity entity)
        {

            var result = _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return Result<ProductEntity>.Success(result.Entity);
        }

        public Result<IEnumerable<ProductEntity>> GetAllProducts()
        {
            var result = _context.Products.ToList();
            return Result<IEnumerable<ProductEntity>>.Success(result);
        }

        public async Task<Result<ProductEntity>> UpdateProduct(ProductEntity entity)
        {
           var findProduct = await  _context.Products.FindAsync(entity.Id);
           if (findProduct != null)
           {
               findProduct.Name = entity.Name;
               findProduct.Description = entity.Description;
               findProduct.Price = entity.Price;
               await _context.SaveChangesAsync();
               return Result<ProductEntity>.Success(findProduct);
           }
           else
           {
               return Result<ProductEntity>.Failure($"{entity.Id} Not Found");
           }
        }
    }
}
