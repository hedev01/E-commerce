using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Entities;
using E_Commers.Core.Model;

namespace E_Commers.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Result<CategoryEntity>> AddCategory(CategoryEntity category);
        Result<List<CategoryEntity>> GetAllCategory();

        Task<Result<CategoryEntity>> GetCategoryById(int id);
        Task<Result<CategoryEntity>> UpdateCategoryById(string name , int id);
    }
}
