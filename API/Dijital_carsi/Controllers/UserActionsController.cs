using Business.Interfaces;
using Business.Services;
using DataAccess.EntityFramework;
using Dijital_carsi.DTOs;
using Dijital_carsi.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dijital_carsi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly InterfaceUserService userService;
        private readonly InterfaceTokenService tokenService;
        public UserActionsController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, InterfaceUserService userService, InterfaceTokenService tokenService) {
            this.userManager = userManager;
            this.userService = userService;
            this.tokenService = tokenService;
            this.context = dbContext;
        
        }

       [HttpGet("GetAllUsers")]
        [Authorize(Roles ="adminRole")]
       public async Task<IActionResult> GetAllUsers()
        {
            var result = await userService.GetAllUsersAsync();
            
            return result!=null ? Ok(result) : BadRequest(result);    
        }

        [HttpPost("RegisterUser")]
       
        private async Task<IActionResult> RegisterUser(SignUpUserDTO request, string role)
        {
            if (request == null)
            {
                return BadRequest("Invalid request");
            }

            var existingUserEmailResult = await userService.GetUserByEmailAsync(request.Email);
            if (existingUserEmailResult.Success && existingUserEmailResult.Data != null)
            {
                return BadRequest("A user with the same email already exists");
            }

            var existingUsernameResult = await userService.GetUserByNameAsync(request.Username);
            if (existingUsernameResult.Success && existingUsernameResult.Data != null)
            {
                return BadRequest("A user with the same username already exists");
            }

            var user = new IdentityUser
            {
                Email = request.Email.Trim(),
                UserName = request.Username.Trim(),
                PhoneNumber = request.PhoneNumber.Trim(),
            };

            var signUpResult = await userService.SignUpAsync(user, request.Password);
            if (!signUpResult.Success)
            {
                return BadRequest(signUpResult.Message);
            }

            var roleAssignmentResult = await userService.AddToRoleAsync(user, role);
            if (!roleAssignmentResult.Success)
            {
                return BadRequest(roleAssignmentResult.Message);
            }

            return Ok($"An account has been created and {role} has been assigned");
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpUser(SignUpUserDTO request)
        {
            return await RegisterUser(request, "userRole");
        }

        [HttpPost("ShopOwnerSignUp")]
        public async Task<IActionResult> ShopOwnerSignUp(SignUpUserDTO request)
        {
            return await RegisterUser(request, "shopOwnerRole");
        }

        [HttpPost("SupportUserRegister")]
        [Authorize(Roles = "adminRole")]
        public async Task<IActionResult> SupportUserRegister(SignUpUserDTO request)
        {
            return await RegisterUser(request, "supportRole");
        }


        [HttpDelete]
        [Authorize(Roles ="userRole")]
        [Route("UserDelete/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]string id)
        {
            var result = await userService.DeleteUserAsync(id);
               if (!result.Success)
            {
                return BadRequest(result.Message.ToString());
            }
               return Ok(result.Message.ToString());
        }

        [HttpPost ("Login")]

        public async Task<IActionResult> Login(UserLoginDTO request)
        {
            var result = await userService.LoginAsync(request.Email,request.Password,request.Username);
            if (!result.Success)
            {
                return BadRequest(result.Message.ToString());
            }
            var user=result.Data;

            var rolesResult = await userService.GetRolesAsync(user);
            if (!rolesResult.Success)
            {
                return BadRequest(result.Message.ToString());
            }

            var roles = rolesResult.Data;

            var tokenResult = await tokenService.CreateJwtTokenAsync(user, roles, request.RememberMe);
            
            if(!tokenResult.Success)
            {
                return BadRequest($"{tokenResult.Message}");
            }
            var token = tokenResult.Data;

            var response = new LoginResponseDTO
            {
                Token = token,
                Message = result.Message,
                Successful =result.Success,
            };
            

            return Ok(response);
        }


        //[HttpGet]
        //[Route("GetUserByID/{id}")]
        ////[Authorize(Roles ="userRole"||"shopOwnerRole"||"supportRole")]
        //public async Task<IActionResult> GetUserByID([FromRoute]string id)
        //{

        //}
    }
}
