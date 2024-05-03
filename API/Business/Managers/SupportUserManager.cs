using Business.Interfaces;
using Core.Entities.Domains;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class SupportUserManager:InterfaceSupportUserService
    {
        private readonly UserManager<SupportUser> _userManager;

        public SupportUserManager(UserManager<SupportUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IDataResult<SupportUser>> GetSupportUserById(string supportUserId)
        {
            try
            {
                var supportUser = await _userManager.FindByIdAsync(supportUserId);
                if (supportUser == null)
                    return new ErrorDataResult<SupportUser>(null, "Support user not found.");

                return new SuccessDataResult<SupportUser>(supportUser, "Support user retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<SupportUser>(null, $"Error retrieving support user: {ex.Message}");
            }
        }

        public async Task<IDataResult<List<SupportUser>>> GetAllSupportUsers()
        {
            try
            {
                var supportUsers = await _userManager.Users.ToListAsync();
                return new SuccessDataResult<List<SupportUser>>(supportUsers, "All support users retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<SupportUser>>(null, $"Error retrieving all support users: {ex.Message}");
            }
        }

        public async Task<IResult> CreateSupportUser(SupportUser supportUser, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(supportUser, password);
                return result.Succeeded
                    ? new SuccessResult("Support user created successfully.")
                    : new ErrorResult($"Error creating support user: {string.Join(", ", result.Errors)}");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error creating support user: {ex.Message}");
            }
        }

        public async Task<IResult> UpdateSupportUser(SupportUser supportUser)
        {
            try
            {
                var result = await _userManager.UpdateAsync(supportUser);
                return result.Succeeded
                    ? new SuccessResult("Support user updated successfully.")
                    : new ErrorResult($"Error updating support user: {string.Join(", ", result.Errors)}");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error updating support user: {ex.Message}");
            }
        }

        public async Task<IResult> DeleteSupportUser(string supportUserId)
        {
            try
            {
                var supportUser = await _userManager.FindByIdAsync(supportUserId);
                if (supportUser == null)
                    return new ErrorResult("Support user not found.");

                var result = await _userManager.DeleteAsync(supportUser);
                return result.Succeeded
                    ? new SuccessResult("Support user deleted successfully.")
                    : new ErrorResult($"Error deleting support user: {string.Join(", ", result.Errors)}");
            }
            catch (Exception ex)
            {
                return new ErrorResult($"Error deleting support user: {ex.Message}");
            }
        }
    }
}
