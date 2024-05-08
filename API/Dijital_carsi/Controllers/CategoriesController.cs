using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using Dijital_carsi.DTOs.Category;
using Dijital_carsi.DTOs.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly InterfaceCategoryService _CategoryService;

        public CategoriesController(InterfaceCategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }


        //---------------GET----------------
        //GET ALL
        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await _CategoryService.GetAllCategories();

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Category => new CategoryInfoDTO
                {
                    Description = Category.Description,
                    Id = Category.Id,
                    IsActive = Category.IsActive,
                    Name = Category.Name,
                }).ToList();

                var response = new CommonResponseDTO<List<CategoryInfoDTO>>()
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
            }
        }
       
        //GET ACTIVE CATEGORIES
        [HttpGet("GetActiveCategories")]
        public async Task<IActionResult> GetActiveCategories()
        {
            try
            {
                var result = await _CategoryService.GetAllActiveCategories(true);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = result.Data.Select(Category => new CategoryInfoDTO
                {
                    Description = Category.Description,
                    Id = Category.Id,
                    IsActive = Category.IsActive,
                    Name = Category.Name,
                }).ToList();

                var response = new CommonResponseDTO<List<CategoryInfoDTO>>()
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
            }
        }

        //GET CATEGORY BY ID
        [HttpGet("GetCategoryById/{CategoryId:guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid CategoryId)
        {
            try
            {
                var result = await _CategoryService.GetCategoryById(CategoryId);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new CategoryInfoDTO
                {
                    Description = result.Data.Description,
                    Id = result.Data.Id,
                    IsActive = result.Data.IsActive,
                    Name = result.Data.Name,
                };

                var response = new CommonResponseDTO<CategoryInfoDTO>()
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
            }

        }

        //GET CATEGORY BY NAME
        [HttpGet("GetCategoryByName/{CategoryName}")]
        public async Task<IActionResult> GetCategoryByName([FromRoute] string CategoryName)
        {
            try
            {
                var result = await _CategoryService.GetCategoryByName(CategoryName);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var resultData = new CategoryInfoDTO
                {
                    Description = result.Data.Description,
                    Id = result.Data.Id,
                    IsActive = result.Data.IsActive,
                    Name = result.Data.Name,
                };

                var response = new CommonResponseDTO<CategoryInfoDTO>()
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
            }
        }



        //---------------POST----------------

        //CREATE CATEGORY
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryCreateRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var CreateRequest = new Category
                {
                    Description = request.Description,
                    Name = request.Name,
                    IsActive = false

                };

                var CreateResult = await _CategoryService.CreateCategory(CreateRequest);
                if (!CreateResult.Success)
                {
                    return BadRequest(CreateResult.Message);
                }


                return Ok($"New category has been created");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }



        //---------------PUT----------------

        //UPDATE CATEGORY
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryCreateRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var UpdateRequest = new Category
                {
                    Description = request.Description,
                    Name = request.Name,


                };

                var UpdateResult = await _CategoryService.UpdateCategory(UpdateRequest);
                if (!UpdateResult.Success)
                {
                    return BadRequest(UpdateResult.Message);
                }


                return Ok($"Category has been Updated");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //TOGGLE STATUS
        [HttpPut("ToggleCategoryStatus/{CategoryId:Guid}")]
        //[Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> OpenCloseShop([FromRoute] Guid CategoryId, bool ToggleStatus)
        {
            try
            {

                var result = await _CategoryService.UpdateStatus(CategoryId, ToggleStatus);
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

        //DELETE CATEGORY
        [HttpDelete("DeleteCategory/{CategoryId:guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid CategoryId)
        {
            try
            {
                if (CategoryId == null)
                {
                    return BadRequest("Invalid request");
                }



                var DeleteResult = await _CategoryService.DeleteCategory(CategoryId);
                if (!DeleteResult.Success)
                {
                    return BadRequest(DeleteResult.Message);
                }


                return Ok($"Category has been Deleted");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }



    }
}
