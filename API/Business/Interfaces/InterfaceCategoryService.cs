using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceCategoryService
    {
        Task<IDataResult<Category>> GetCategoryById(Guid id);
        Task<IDataResult<Category>> GetCategoryByName(string name);
        Task<IDataResult<List<Category>>> GetAllActiveCategories(bool isActive);
        Task<IDataResult<List<Category>>> GetAllCategories();
        Task<IResult> CreateCategory(Category category);
        Task<IResult> UpdateCategory(Category category);
        Task<IResult> UpdateStatus(Guid categoryId, bool isActive);
        Task<IResult> DeleteCategory(Guid categoryId);
    }
}
