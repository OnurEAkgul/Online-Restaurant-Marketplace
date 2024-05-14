using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceProductService
    {

        Task<IDataResult<Product>> GetProductById(Guid productId);
        Task<IDataResult<List<Product>>> GetProductsByName(string name);
        Task<IDataResult<List<Product>>> GetProductsByShopId(Guid ShopId);
        Task<IDataResult<Product>> GetProductByName(string name);
        Task<IDataResult<List<Product>>> GetProductsByCategory(Guid categoryId);
        Task<IDataResult<List<Product>>> GetProductsByCategoryName(string name);
        Task<IDataResult<List<Product>>> GetAllProducts();
        Task<IResult> CreateProduct(Product product);
        Task<IResult> UpdateProduct(Product product);
        Task<IResult> ToggleProductStatus(Guid productId, bool isActive);
        Task<IResult> DeleteProduct(Guid productId);



    }
}
