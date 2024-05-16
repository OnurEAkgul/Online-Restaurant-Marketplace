using Business.Interfaces;
using Core.Utilities.Results;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserManager : InterfaceUserService
    {
        private readonly ApplicationDbContext Context;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;

        public UserManager(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            Context = context;
            _UserManager = userManager;
            _RoleManager = roleManager;
        }

        //CRUD METHODS
        public async Task<IDataResult<IdentityUser>> LoginAsync(string email, string password, string username)
        {
            try
            {
                IdentityUser User = null;

                if (!string.IsNullOrEmpty(email))
                {
                    User = await _UserManager.FindByEmailAsync(email);
                }
                if (User == null && !string.IsNullOrEmpty(username))
                {

                    User = await _UserManager.FindByNameAsync(username);

                }
                if (User != null && await _UserManager.CheckPasswordAsync(User, password))
                {
                    return new SuccessDataResult<IdentityUser>(User, "User login successful");
                }
                return new ErrorDataResult<IdentityUser>(null, "Invaild email or password");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IdentityUser>(null, $"An error occured when logging in: {ex.Message}");
            }
        }

        public async Task<IResult> SignUpAsync(IdentityUser user, string password)
        {
            try
            {
                var Result = await _UserManager.CreateAsync(user, password);
                
                return Result.Succeeded
                    ? new SuccessResult("User Registered Successfully")
                    : new ErrorResult(string.Join(",", "User Registeration Error"));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occured when signing up: {ex.Message}");
            }

        }
        public async Task<IResult> AddToRoleAsync(IdentityUser user, string role)
        {
            try
            {
                var Result = await _UserManager.AddToRoleAsync(user, role);
                if (Result.Succeeded)
                {
                    return new SuccessResult($"User added to the {role} role successfully.");
                }
                else
                {
                    var errors = Result.Errors.Select(e => e.Description).ToList();
                    return new ErrorResult(string.Join(", ", errors));
                }

            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occured when assigning a role: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteUserAsync(string userId)
        {
            try
            {
                var User = await _UserManager.FindByIdAsync(userId);

                if (User == null)
                {
                    return new ErrorResult("User not found.");
                }

                var Result = await _UserManager.DeleteAsync(User);

                return Result.Succeeded
                    ? new SuccessResult("User deleted successfully.")
                    : new ErrorResult(string.Join(", ", "Error occured while deleting user"));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occured when deleting user: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateUserAsync(IdentityUser user)
        {
            try
            {
                if (user == null)
                {
                    return new ErrorResult("User not found.");
                }
                var Result = await _UserManager.UpdateAsync(user);

                return Result.Succeeded
                    ? new SuccessResult("User updated successfully.")
                    : new ErrorResult(string.Join(", ", "Error occured while updating user "));
            }
            catch (Exception ex)
            {
                return new ErrorResult($"An error occured when updating user: {ex.Message}");
            }
        }

        //GET METHODS
        public async Task<IDataResult<List<IdentityUser>>> GetAllUsersAsync()
        {
            try
            {
                var Users = await Task.Run(() => _UserManager.Users.ToList());
                return new SuccessDataResult<List<IdentityUser>>(Users, "Users retrieved successfully.");
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<IdentityUser>>(null, $"An error occured when deleting user: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<IdentityUser>>> GetUsersByRoleAsync(string roleName)
        {
            try
            {
                var role = await _RoleManager.FindByNameAsync(roleName);

                if (role == null)
                {
                    return new ErrorDataResult<List<IdentityUser>>(null, $"Role '{roleName}' not found.");
                }

                var usersInRole = await _UserManager.GetUsersInRoleAsync(roleName);

                return new SuccessDataResult<List<IdentityUser>>(usersInRole.ToList(), $"Users in role '{roleName}' retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<IdentityUser>>(null, $"An error occurred when retrieving users for role '{roleName}': {ex.Message}");
            }
        }

        public async Task<IDataResult<List<string>>> GetRolesAsync(IdentityUser user)
        {
            try
            {
                var Roles = await _UserManager.GetRolesAsync(user) as List<string>;

                if (Roles == null || Roles.Count == 0)
                {
                    var RoleClaims = await _UserManager.GetClaimsAsync(user);

                    Roles = RoleClaims
                        .Where(rc => rc.Type == ClaimTypes.Role)
                        .Select(rc => rc.Value)
                        .ToList();
                }

                return new SuccessDataResult<List<string>>(Roles, "Roles retrieved successfully.");
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<List<string>>(null, $"An error occured when retrieveing roles: {ex.Message}");
            }
        }

        public async Task<IDataResult<IdentityUser>> GetUserByEmailAsync(string email)
        {
            try
            {
                var User = await _UserManager.FindByEmailAsync(email);

                return User != null
                    ? new SuccessDataResult<IdentityUser>(User, "User retrieved successfully.")
                    : new ErrorDataResult<IdentityUser>(null, "User not found.");
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<IdentityUser>(null, $"An error occured when retrieveing user: {ex.Message}");
            }
        }

        public async Task<IDataResult<IdentityUser>> GetUserByIdAsync(string userId)
        {
            try
            {
                var User = await _UserManager.FindByIdAsync(userId);

                return User != null
                    ? new SuccessDataResult<IdentityUser>(User, "User retrieved successfully.")
                    : new ErrorDataResult<IdentityUser>(User, "User not found.");
            }

            catch (Exception ex)
            {
                return new ErrorDataResult<IdentityUser>(null, $"An error occured when retrieveing user: {ex.Message}");
            }

        }

        public async Task<IDataResult<IdentityUser>> GetUserByNameAsync(string name)
        {
            try
            {
                var User = await _UserManager.FindByNameAsync(name);

                return User != null
                     ? new SuccessDataResult<IdentityUser>(User, "User retrieved succesfully.")
                     : new ErrorDataResult<IdentityUser>(null, "User not found.");

            }

            catch (Exception ex)
            {
                return new ErrorDataResult<IdentityUser>(null, $"An error occured when retrieveing user: {ex.Message}");
            }

        }




    }
}
