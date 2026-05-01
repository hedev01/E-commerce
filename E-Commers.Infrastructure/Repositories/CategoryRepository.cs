using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commers.Core.Entities;
using E_Commers.Core.Interfaces;
using E_Commers.Core.Model;
using E_Commers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commers.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async Task<Result<CategoryEntity>> AddCategory(CategoryEntity category)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == category.Name.ToLower());
            if (existingCategory != null)
            {
                return Result<CategoryEntity>.Failure($"A category with the name '{category.Name}' already exists.");
            }

            CategoryEntity categoryEntity = new CategoryEntity()
            {
                Name = category.Name,
              //  Id = category.Id
            }; 
             _context.Categories.Add(categoryEntity);
           await  _context.SaveChangesAsync();
           return Result<CategoryEntity>.Success(categoryEntity);
        }
    }
}
