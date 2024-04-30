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

        public UserManager(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            Context = context;
            _UserManager = userManager;
        }

        //CRUD METHODS
        public async Task<IDataResult<IdentityUser>> LoginAsync(string email, string password, string username)
        {
            IdentityUser User = null;

            if (!string.IsNullOrEmpty(email))
            {
                User = await _UserManager.FindByIdAsync(email);
            }
            if (User == null && !string.IsNullOrEmpty(username))
            {

                User = await _UserManager.FindByNameAsync(username);

            }
            if (User != null && await _UserManager.CheckPasswordAsync(User, password))
            {
                return new SuccessDataResult<IdentityUser>(User, password);
            }
            return new ErrorDataResult<IdentityUser>(null, "Invaild email or password");
        }

        public async Task<IResult> SignUpAsync(IdentityUser user, string password)
        {
            var Result = await _UserManager.CreateAsync(user, password);
            return Result.Succeeded
                ? new SuccessResult("User Registered Successfully")
                : new ErrorResult(string.Join(",", "User Registeration Error"));
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
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> DeleteUserAsync(string userId)
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

        public async Task<IResult> UpdateUserAsync(IdentityUser user)
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

        //GET METHODS
        public async Task<IDataResult<List<IdentityUser>>> GetAllUsersAsync()
        {
            var Users = await Task.Run(() => _UserManager.Users.ToList());
            return new SuccessDataResult<List<IdentityUser>>(Users, "Users retrieved successfully.");
        }

        public async Task<List<string>> GetRolesAsync(IdentityUser user)
        {
            var Roles = await _UserManager.GetRolesAsync(user) as List<string>;

            if (Roles == null || Roles.Count == 0)
            {
                var RoleClaims = await _UserManager.GetClaimsAsync(user);

                Roles = RoleClaims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();
            }

            return Roles;
        }

        public async Task<IDataResult<IdentityUser>> GetUserByEmailAsync(string email)
        {
            var User = await _UserManager.FindByEmailAsync(email);

            return User != null
                ? new SuccessDataResult<IdentityUser>(User, "User retrieved successfully.")
                : new ErrorDataResult<IdentityUser>(null, "User not found.");
        }

        public async Task<IDataResult<IdentityUser>> GetUserByIdAsync(string userId)
        {
            var User = await _UserManager.FindByIdAsync(userId);

            return User != null
                ? new SuccessDataResult<IdentityUser>(User, "User retrieved successfully.")
                : new ErrorDataResult<IdentityUser>(User, "User not found.");
        }

        public async Task<IDataResult<IdentityUser>> GetUserByNameAsync(string name)
        {
            var User = await _UserManager.FindByNameAsync(name);

            return User != null
                 ? new SuccessDataResult<IdentityUser>(User, "User retrieved succesfully.")
                 : new ErrorDataResult<IdentityUser>(null, "User not found.");
        }




    }
}
