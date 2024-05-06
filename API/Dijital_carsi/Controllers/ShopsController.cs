using Azure.Core;
using Business.Interfaces;
using Core.Entities.Domains;
using DataAccess.EntityFramework;
using Dijital_carsi.DTOs.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly InterfaceShopService _shopService;
        private readonly InterfaceUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        public ShopsController(ApplicationDbContext dbContext, InterfaceShopService shopService, InterfaceUserService userService, UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            _shopService = shopService;
            _userService = userService;
            _userManager = userManager;
        }



        [HttpPost("CreateNewShop")]
        [Authorize(Roles = "shopOwnerRole")]
        public async Task<IActionResult> CreateNewShop(CreateShopDTO request, string UserId)
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
                    LogoUrl=""

                };

                var CreateResult = await _shopService.CreateShopAsync(CreateRequest);
                if (!CreateResult.Success)
                {
                    return BadRequest(CreateResult.Message);
                }
                /*
                 {
  "name": "Anadolu Tat 1071",
  "description": "Anadolu Tat 1071 Ev Yemekleri Lokantasi",
  "location": "Taşçılar İş Merkez, Taya Hatun, 34120 Fatih/İstanbul",
  "contactEmail": "restoran1@gmail.com",
  "contactPhone": "031255555555"
}*/


                return Ok($"Your shop has been created");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

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

                var resultData= result.Data.Select(shop => new ShopInfoDTO
                {
                    Name = shop.Name,
                    Description = shop.Description,
                    Location = shop.Location,
                    ContactEmail = shop.ContactEmail,
                    ContactPhone = shop.ContactPhone,
                    LogoUrl = shop.LogoUrl,
                    IsOpen = shop.IsOpen
                }).ToList();

                var response = new ShopResponseDTO
                {
                    Message="All shops has been listed",
                    Data=resultData,
                    Successful=true
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
