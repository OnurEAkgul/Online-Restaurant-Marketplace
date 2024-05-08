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

namespace Business.Services
{
    public class ProductManager :InterfaceProductService
    {

        private readonly InterfaceProductDAL _productDAL;

        public ProductManager(InterfaceProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public async Task<IDataResult<Product>> GetProductById(Guid productId)
        {
            try
            {
                var product = await _productDAL.GetAsync(p => p.Id == productId, includeProperties: "Category,Shops");
                if (product == null)
                    return new ErrorDataResult<Product>(null, "Product not found.");

                return new SuccessDataResult<Product>(product, "Product retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(null, $"Error retrieving product: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Product>>> GetAllProducts()
        {
            try
            {
                var products = await _productDAL.GetAllAsync(includeProperties: "Category,Shops");
                return new SuccessDataResult<List<Product>>(products, "All products retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, $"Error retrieving all products: {ex.Message}");
            }
        }

        public async Task<IResult> CreateProduct(Product product)
        {
            try
            {
                await _productDAL.AddAsync(product);
                return new SuccessResult("Product created successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error creating product: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateProduct(Product product)
        {
            try
            {
                await _productDAL.UpdateAsync(product);
                return new SuccessResult("Product updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating product: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteProduct(Guid productId)
        {
            try
            {
                var product = new Product { Id = productId };
                await _productDAL.DeleteAsync(product);
                return new SuccessResult("Product has been deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting product: {ex.Message}");
            }
        }

        

        public async Task<IDataResult<List<Product>>> GetProductsByCategory(Guid categoryId)
        {
            try
            {
                var product = await _productDAL.GetAllAsync(p => p.CategoryId == categoryId);
                if (product.Count == 0)
                    return new ErrorDataResult<List<Product>>(null, "Product not found.");

                return new SuccessDataResult<List<Product>>(product, "Products retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, $"Error retrieving product: {ex.Message}");
            }
        }
        public async Task<IDataResult<List<Product>>> GetProductsByCategoryName(string name)
        {
            try
            {
                var product = await _productDAL.GetAllAsync(p => p.Category.Name.Contains(name) );
                if (product.Count == 0)
                    return new ErrorDataResult<List<Product>>(null, "Product not found.");

                return new SuccessDataResult<List<Product>>(product, "Products retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, $"Error retrieving product: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<Product>>> GetProductsByName(string name)
        {
            try
            {
                var product = await _productDAL.GetAllAsync(p => p.Name.Contains(name) );
                if (product.Count == 0)
                    return new ErrorDataResult<List<Product>>(null, "Product not found.");

                return new SuccessDataResult<List<Product>>(product, "Products retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Product>>(null, $"Error retrieving product: {ex.Message}");
            }
        }
        public async Task<IDataResult<Product>> GetProductByName(string name)
        {
            try
            {
                var product = await _productDAL.GetAsync(p => p.Name == name);
                if (product == null)
                    return new ErrorDataResult<Product>(null, "Product not found.");

                return new SuccessDataResult<Product>(product, "Products retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Product>(null, $"Error retrieving product: {ex.Message}");
            }
        }
    }
}
