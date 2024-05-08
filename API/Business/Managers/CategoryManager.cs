using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class CategoryManager : InterfaceCategoryService
    {
        private readonly InterfaceCategoryDAL _categoryDAL ;
        public CategoryManager(InterfaceCategoryDAL categoryDAL) { 
        
            _categoryDAL = categoryDAL;
        }
        public async Task<IResult> CreateCategory(Category category)
        {
            try
            {
                await _categoryDAL.AddAsync(category);
                return new SuccessResult("Category created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error creating Category: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateCategory(Category category)
        {
            try
            {
                await _categoryDAL.UpdateAsync(category);
                return new SuccessResult("Category updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating Category: {ex.Message}");
            }
        }
        public async Task<IResult> DeleteCategory(Guid id)
        {
            try
            {
                var category = new Category { Id = id };
                await _categoryDAL.DeleteAsync(category);
                return new SuccessResult("Category has been deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting category: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Category>>> GetAllActiveCategories(bool isActive)
        {
            try
            {
                var category = await _categoryDAL.GetAllAsync(c => c.IsActive == isActive);
                if (category == null)
                    return new ErrorDataResult<List<Category>>(null, "Category not found.");

                return new SuccessDataResult<List<Category>>(category, "category retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Category>>(null, $"Error retrieving category: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Category>>> GetAllCategories()
        {
            try
            {
                var category = await _categoryDAL.GetAllAsync();
                if (category == null)
                    return new ErrorDataResult<List<Category>>(null, "Category not found.");

                return new SuccessDataResult<List<Category>>(category, "category retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Category>>(null, $"Error retrieving category: {ex.Message}");
            }
        }

        public async Task<IDataResult<Category>> GetCategoryById(Guid id)
        {
            try
            {
                var category = await _categoryDAL.GetAsync(c => c.Id == id);
                if (category == null)
                    return new ErrorDataResult<Category>(null, "Category not found.");

                return new SuccessDataResult<Category>(category, "category retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Category>(null, $"Error retrieving category: {ex.Message}");
            }
        }

        public async Task<IDataResult<Category>> GetCategoryByName(string name)
        {
            try
            {
                var category = await _categoryDAL.GetAsync(c => c.Name == name);
                if (category == null)
                    return new ErrorDataResult<Category>(null, "Category not found.");

                return new SuccessDataResult<Category>(category, "category retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Category>(null, $"Error retrieving category: {ex.Message}");
            }
        }

        
    }
}
