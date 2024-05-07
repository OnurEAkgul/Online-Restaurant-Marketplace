﻿using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using DataAccess.EntityFramework;
using Dijital_carsi.DTOs.Common;
using Dijital_carsi.DTOs.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        
        private readonly InterfaceShopService _shopService;
        
        public ShopsController(ApplicationDbContext dbContext, InterfaceShopService shopService, InterfaceUserService userService, UserManager<IdentityUser> userManager)
        {
           
            _shopService = shopService;
            
        }

        //CREATE
        [HttpPost("CreateNewShop/{UserId}")]
        [Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> CreateNewShop(CreateShopDTO request, [FromRoute] string UserId)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request");
                }

                var CreateRequest = new Shop
                {
                    ContactEmail = request.ContactEmail,
                    ContactPhone = request.ContactPhone,
                    Description = request.Description,
                    Location = request.Location,
                    Name = request.Name,
                    ShopOwnerId = UserId,
                    LogoUrl = ""

                };

                var CreateResult = await _shopService.CreateShopAsync(CreateRequest);
                if (!CreateResult.Success)
                {
                    return BadRequest(CreateResult.Message);
                }


                return Ok($"Your shop has been created");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        //UPDATE
        [HttpPut("UpdateShopInfo/{shopId:Guid}")]
        [Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> UpdateShopInformation(ShopUpdateRequestDTO shopUpdate, [FromRoute] Guid shopId)
        {
            try
            {

                var request = new Shop
                {
                    Id = shopId,
                    ContactEmail = shopUpdate.ContactEmail,
                    ContactPhone = shopUpdate.ContactPhone,
                    LogoUrl = shopUpdate.LogoUrl,
                    IsOpen = shopUpdate.IsOpen,
                    Description = shopUpdate.Description,
                    Location = shopUpdate.Location,
                    Name = shopUpdate.Name
                };

                var result = await _shopService.UpdateShopAsync(request);
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
        
        //DELETE
        [HttpDelete("RemoveShop/{shopId:Guid}")]
        [Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> RemoveShop([FromRoute] Guid shopId)
        {
            try
            {

                var request = new Shop
                {
                    Id = shopId,
                };

                var result = await _shopService.DeleteShopAsync(request);
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

        //TOGGLE STATUS
        [HttpPut("OpenCloseShop/{shopId:Guid}")]
        [Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> OpenCloseShop([FromRoute] Guid shopId, bool ToggleStatus)
        {
            try
            {

                var result = await _shopService.ToggleShopStatusAsync(shopId, ToggleStatus);
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

        //GET OPEN
        [HttpGet("GetOpenShops")]
        public async Task<IActionResult> GetOpenShops()
        {
            try
            {
                var result = await _shopService.GetShopsByStatusAsync(true);
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }

                var resultData = result.Data.Select(shop => new ShopInfoDTO
                {
                    Name = shop.Name,
                    Description = shop.Description,
                    Location = shop.Location,
                    ContactEmail = shop.ContactEmail,
                    ContactPhone = shop.ContactPhone,
                    LogoUrl = shop.LogoUrl,
                    IsOpen = shop.IsOpen
                }).ToList();

                var response = new CommonResponseDTO<List<ShopInfoDTO>>()
                {
                    Message = "All Open shops has been listed",
                    Data = resultData,
                    Successful = true
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET ALL
        [HttpGet("GetShops")]
        public async Task<IActionResult> GetShops()
        {
            try
            {
                var result = await _shopService.GetAllShops();
                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }

                var resultData = result.Data.Select(shop => new ShopInfoDTO
                {
                    Name = shop.Name,
                    Description = shop.Description,
                    Location = shop.Location,
                    ContactEmail = shop.ContactEmail,
                    ContactPhone = shop.ContactPhone,
                    LogoUrl = shop.LogoUrl,
                    IsOpen = shop.IsOpen
                }).ToList();

                var response = new CommonResponseDTO<List<ShopInfoDTO>>()
                {
                    Message = "All shops has been listed",
                    Data = resultData,
                    Successful = true
                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET BY NAME
        [HttpGet("GetShopsByName")]
        public async Task<IActionResult> GetShopsByName([FromQuery] string name=null)
        {
            try
            {
                if(name.IsNullOrEmpty())
                {
                    var NullResult = await _shopService.GetAllShops();
                    if (!NullResult.Success)
                    {
                        return BadRequest(NullResult.Message);
                    }

                    var NullResultData = NullResult.Data.Select(shop => new ShopInfoDTO
                    {
                        Name = shop.Name,
                        Description = shop.Description,
                        Location = shop.Location,
                        ContactEmail = shop.ContactEmail,
                        ContactPhone = shop.ContactPhone,
                        LogoUrl = shop.LogoUrl,
                        IsOpen = shop.IsOpen
                    }).ToList();

                    var NullResponse = new CommonResponseDTO<List<ShopInfoDTO>>()
                    {
                        Message = "All shops has been listed",
                        Data = NullResultData,
                        Successful = true
                    };
                    return Ok(NullResponse);

                }

                var NameResult = await _shopService.GetShopsByNameAsync(name);
                if (!NameResult.Success)
                {
                    return BadRequest(NameResult.Message);
                }

                var NameResultData = NameResult.Data.Select(shop => new ShopInfoDTO
                {
                    Name = shop.Name,
                    Description = shop.Description,
                    Location = shop.Location,
                    ContactEmail = shop.ContactEmail,
                    ContactPhone = shop.ContactPhone,
                    LogoUrl = shop.LogoUrl,
                    IsOpen = shop.IsOpen
                }).ToList();

                var response = new CommonResponseDTO<List<ShopInfoDTO>>()
                {
                    Message = "All shops has been listed",
                    Data = NameResultData,
                    Successful = true
                };
                return Ok(response);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        //GET BY NAME
        [HttpGet("GetShopById/{shopId:Guid}")]
        public async Task<IActionResult> GetShopsById([FromRoute] Guid shopId)
        {
            try
            {
                
                var result = await _shopService.GetShopByIdAsync(shopId);
                if (!result.Success)
                {
                    return BadRequest(result);
                }

                var responseData = new ShopInfoDTO
                {
                    Name = result.Data.Name,
                    Description = result.Data.Description,
                    Location = result.Data.Location,
                    ContactEmail = result.Data.ContactEmail,
                    ContactPhone = result.Data.ContactPhone,
                    LogoUrl = result.Data.LogoUrl,
                    IsOpen = result.Data.IsOpen
                };

                var response = new CommonResponseDTO<ShopInfoDTO>
                {
                    Message = "Shop has been listed",
                    Data = responseData,
                    Successful = true
                };
                return Ok(response);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }




    }
}
