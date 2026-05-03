using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Entities;
using E_Commers.Core.Model;

namespace E_Commers.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Result<ProductEntity>> AddProduct(ProductEntity entity);
    }
}
