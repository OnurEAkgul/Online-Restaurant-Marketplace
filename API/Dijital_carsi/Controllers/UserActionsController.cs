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
        public UserActionsController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, InterfaceUserService userService, InterfaceTokenService tokenService)
        {
            this.userManager = userManager;
            this.userService = userService;
            this.tokenService = tokenService;
            this.context = dbContext;

        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "adminRole")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await userService.GetAllUsersAsync();

                return result != null ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("RegisterUser")]

        private async Task<IActionResult> RegisterUser(SignUpUserDTO request, string role)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUpUser(SignUpUserDTO request)
        {
            try
            {
                return await RegisterUser(request, "userRole");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("ShopOwnerSignUp")]
        public async Task<IActionResult> ShopOwnerSignUp(SignUpUserDTO request)
        {
            try
            {
                return await RegisterUser(request, "shopOwnerRole");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpPost("SupportUserRegister")]
        [Authorize(Roles = "adminRole")]
        public async Task<IActionResult> SupportUserRegister(SignUpUserDTO request)
        {
            try
            {
                return await RegisterUser(request, "supportRole");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete]
        [Authorize(Roles = "userRole")]
        [Route("UserDelete/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            try
            {
                var result = await userService.DeleteUserAsync(id);
                if (!result.Success)
                {
                    return BadRequest(result.Message.ToString());
                }
                return Ok(result.Message.ToString());

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(UserLoginDTO request)
        {

            try
            {
                var result = await userService.LoginAsync(request.Email, request.Password, request.Username);
                if (!result.Success)
                {
                    return BadRequest(result.Message.ToString());
                }
                var user = result.Data;

                var rolesResult = await userService.GetRolesAsync(user);
                if (!rolesResult.Success)
                {
                    return BadRequest(result.Message.ToString());
                }

                var roles = rolesResult.Data;

                var tokenResult = await tokenService.CreateJwtTokenAsync(user, roles, request.RememberMe);

                if (!tokenResult.Success)
                {
                    return BadRequest($"{tokenResult.Message}");
                }
                var token = tokenResult.Data;

                var response = new LoginResponseDTO
                {
                    Token = token,
                    Message = result.Message,
                    Successful = result.Success,
                };


                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }


        [HttpGet]
        [Route("GetUser")]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                // Await the asynchronous DecodeJwtToken method
                var result = await tokenService.DecodeJwtToken(token);

                if (!result.Success || result.Data == null)
                {
                    return BadRequest("Error decoding or invalid token");
                }

                var claimsDictionary = result.Data;

                // Return the extracted claims dictionary as part of the response
                return Ok(claimsDictionary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("UpdateUserInfo/{id}")]
        [Authorize]
        
        public async Task<IActionResult> UpdateUserInfo([FromRoute]string id, UpdateUserInfoDTO userUpdateDTO, [FromQuery] bool isAdminUpdate)
        {
            // İstek geçerli değilse BadRequest döndür
            if (userUpdateDTO == null)
            {
                return BadRequest("Geçersiz istek");
            }

            using (var Transaction = await context.Database.BeginTransactionAsync())
            {

                try
                {
                    if (isAdminUpdate)
                    {
                        var identityUser = await userManager.FindByIdAsync(id);

                        if (identityUser == null)
                        {
                            return NotFound();
                        }

                        else
                        {
                            // Update the existing IdentityUser with the new information
                            identityUser.UserName = userUpdateDTO.UserName;
                            identityUser.Email = userUpdateDTO.Email;
                            identityUser.NormalizedEmail = userUpdateDTO.Email.Trim().ToUpper();
                            identityUser.NormalizedUserName = userUpdateDTO.UserName.Trim().ToUpper();

                            var result = await userService.UpdateUserAsync(identityUser);

                            if (!result.Success)
                            {
                                throw new Exception(result.Message);
                            }
                        }
                        var response = new UpdateUserInfoDTO { Email = userUpdateDTO.UserName, UserName = userUpdateDTO.Email };
                        await Transaction.CommitAsync();

                        return Ok(response);
                    }

                    else
                    {
                        var identityUser = await userManager.FindByIdAsync(id);

                        if (identityUser == null)
                        {
                            return NotFound();
                        }



                        if (!await userManager.CheckPasswordAsync(identityUser, userUpdateDTO.CurrentPassword))
                        {
                            return BadRequest("Yanlış şifre girdiniz");
                        }


                        if (!string.IsNullOrEmpty(userUpdateDTO.NewPassword))
                        {
                            // Update the existing IdentityUser with the new information
                            identityUser.UserName = userUpdateDTO.UserName;
                            identityUser.Email = userUpdateDTO.Email;
                            identityUser.NormalizedEmail = userUpdateDTO.Email.Trim().ToUpper();
                            identityUser.NormalizedUserName = userUpdateDTO.UserName.Trim().ToUpper();
                            identityUser.PasswordHash = userManager.PasswordHasher.HashPassword(identityUser, userUpdateDTO.NewPassword);

                            var result = await userService.UpdateUserAsync(identityUser);

                            if (!result.Success)
                            {
                                throw new Exception(result.Message);
                            }
                        }
                        else
                        {
                            // Update the existing IdentityUser with the new information
                            identityUser.UserName = userUpdateDTO.UserName;
                            identityUser.Email = userUpdateDTO.Email;
                            identityUser.NormalizedEmail = userUpdateDTO.Email.Trim().ToUpper();
                            identityUser.NormalizedUserName = userUpdateDTO.UserName.Trim().ToUpper();

                            var result = await userService.UpdateUserAsync(identityUser);

                            if (!result.Success)
                            {
                                throw new Exception(result.Message);
                            }
                        }

                        await Transaction.CommitAsync();

                        return Ok(userUpdateDTO);
                    }
                }
                catch (Exception ex)
                {
                    await Transaction.RollbackAsync();
                    throw;
                }
            }
        }
    
    }
}
