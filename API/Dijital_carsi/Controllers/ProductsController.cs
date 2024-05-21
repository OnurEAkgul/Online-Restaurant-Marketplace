using Business.Interfaces;
using Core.Entities.Domains;
using Dijital_carsi.DTOs.CartItem;
using Dijital_carsi.DTOs.Common;
using Dijital_carsi.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //------------------FINISHED---------------------


        private readonly InterfaceProductService _productService;
        public ProductsController(InterfaceProductService productService)
        {

            _productService = productService;

        }



        //---------------GET----------------

        //GET ALL
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await _productService.GetAllProducts();

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(product => new ProductInfoDTO
                {
                    Id = product.Id,
                    CategoryId = product.Category.Id,
                    CategoryName = product.Category.Name,
                    /*Category =
                    //new DTOs.Category.CategoryInfoDTO{
                    //    Description = product.Category.Description,
                    //    Id = product.Category.Id,
                    //    IsActive = product.Category.IsActive,
                    //    Name = product.Category.Name
                    },*/
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Price = product.Price,
                    ShopId = product.ShopId,
                    ShopName = product.Shops.Name,
                }).ToList();


                var response = new CommonResponseDTO<List<ProductInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET BY PRODUCT ID
        [HttpGet("GetProductById/{ProductId:guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid ProductId)
        {
            try
            {
                var result = await _productService.GetProductById(ProductId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new ProductInfoDTO
                {
                    Id = result.Data.Id,
                    CategoryName = result.Data.Category.Name,
                    CategoryId = result.Data.Category.Id,
                    Description = result.Data.Description,
                    ImageUrl = result.Data.ImageUrl,
                    IsActive = result.Data.IsActive,
                    Name = result.Data.Name,
                    Price = result.Data.Price,
                    ShopId = result.Data.ShopId,
                    ShopName = result.Data.Shops.Name,
                };

                var response = new CommonResponseDTO<ProductInfoDTO>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }; 

        }

        //GET BY PRODUCT NAME
        [HttpGet("GetProductsByName/{ProductName}")]
        public async Task<IActionResult> GetProductsByName([FromRoute] string ProductName)
        {
            try
            {
                var result = await _productService.GetProductsByName(ProductName);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(product => new ProductInfoDTO
                {
                    Id = product.Id,
                    CategoryName = product.Category.Name,
                    CategoryId = product.Category.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Price = product.Price,
                    ShopId = product.ShopId,
                    ShopName = product.Shops.Name,
                }).ToList();

                var response = new CommonResponseDTO<List<ProductInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }; 

        }

        //GET BY CATEGORY ID
        [HttpGet("GetProductsByCategory/{CategoryId:Guid}")]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] Guid CategoryId)
        {
            try
            {
                var result = await _productService.GetProductsByCategory(CategoryId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(product => new ProductInfoDTO
                {
                    Id = product.Id,
                    CategoryName = product.Category.Name,
                    CategoryId = product.Category.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Price = product.Price,
                    ShopId = product.ShopId,
                    ShopName = product.Shops.Name,
                }).ToList();

                var response = new CommonResponseDTO<List<ProductInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };

        }

        //GET BY CATEGORY NAME
        [HttpGet("GetProductsByCategoryName/{CategoryName}")]
        public async Task<IActionResult> GetProductsByCategoryName([FromRoute] string CategoryName)
        {
            try
            {
                var result = await _productService.GetProductsByCategoryName(CategoryName);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(product => new ProductInfoDTO
                {
                    Id = product.Id,
                    CategoryName = product.Category.Name,
                    CategoryId = product.Category.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Price = product.Price,
                    ShopId = product.ShopId,
                    ShopName = product.Shops.Name,
                }).ToList();

                var response = new CommonResponseDTO<List<ProductInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };


        }

        //GET BY CATEGORY NAME
        [HttpGet("GetProductsByShopId/{ShopId}")]
        public async Task<IActionResult> GetProductsByCategoryName([FromRoute] Guid ShopId)
        {
            try
            {
                var result = await _productService.GetProductsByShopId(ShopId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(product => new ProductInfoDTO
                {
                    Id = product.Id,
                    CategoryName = product.Category.Name,
                    CategoryId = product.Category.Id,
                    Description = product.Description,
                    ImageUrl = product.ImageUrl,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Price = product.Price,
                    ShopId = product.ShopId,
                    ShopName = product.Shops.Name,
                }).ToList();

                var response = new CommonResponseDTO<List<ProductInfoDTO>>()
                {
                    Data = resultData,
                    Message = result.Message,
                    Successful = result.Success
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            };


        }



        //---------------POST----------------

        //CREATE PRODUCT
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var CreateRequest = new Product
                {
                    CategoryId = request.CategoryId,
                    ImageUrl = request.ImageUrl,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    ShopId = request.ShopId,
                    IsActive = request.IsActive,
                    
                    
                };

                var CreateResult = await _productService.CreateProduct(CreateRequest);
                if (!CreateResult.Success)
                {
                    return BadRequest(CreateResult);
                }


                return Ok(CreateResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //---------------PUT----------------
        
        //UPDATE PRODUCT
        [HttpPut("UpdateProduct/{ProductId:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid ProductId, ProductCreateRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var UpdateRequest = new Product
                {
                    Id = ProductId,
                    CategoryId = request.CategoryId,
                    ImageUrl = request.ImageUrl,
                    Description = request.Description,
                    Name = request.Name,
                    Price = request.Price,
                    ShopId = request.ShopId,
                    IsActive = request.IsActive,
                };

                var UpdateResult = await _productService.UpdateProduct(UpdateRequest);
                if (!UpdateResult.Success)
                {
                    return BadRequest(UpdateResult);
                }


                return Ok(UpdateResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //TOGGLE STATUS
        [HttpPut("ToggleProductStatus/{ProductId:Guid}/{ToggleStatus:bool}")]
        //[Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> ToggleProductStatus([FromRoute] Guid ProductId, bool ToggleStatus)
        {
            try
            {

                var result = await _productService.ToggleProductStatus(ProductId, ToggleStatus);
                if (!result.Success)
                {
                    return BadRequest(result);
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



        //---------------DELETE----------------

        //DELETE PRODUCT
        [HttpDelete("DeleteProduct/{ProductId:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]Guid ProductId)
        {
            try
            {
                if (ProductId == null)
                {
                    return BadRequest("Invalid request");
                }



                var UpdateResult = await _productService.DeleteProduct(ProductId);
                if (!UpdateResult.Success)
                {
                    return BadRequest(UpdateResult);
                }


                return Ok(UpdateResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }








    }
}
