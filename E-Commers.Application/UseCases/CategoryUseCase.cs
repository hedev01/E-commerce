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
    public class CategoryUseCase : ICategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<CategoryEntity>> AddCategory(CategoryEntity category)
        {
            return await _categoryRepository.AddCategory(category);
        }
    }
}
