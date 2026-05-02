using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Entities;
using E_Commers.Core.Model;

namespace E_Commers.Application.InterFaces
{
    public interface ICategoryUseCase
    {
        Task<Result<CategoryEntity>> AddCategory(CategoryEntity entity);
        Result<List<CategoryEntity>> GetAllCategory();
        Task<Result<CategoryEntity>> GetCategoryById(int id);
        Task<Result<CategoryEntity>> UpdateCategoryById(string name, int id);
        Task<Result<bool>> DeleteCategoryById(int id);
    }
}
