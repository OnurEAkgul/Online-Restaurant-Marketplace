using Core.Entities.Domains;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceSupportUserService
    {
        Task<IDataResult<SupportUser>> GetSupportUserById(string supportUserId);
        Task<IDataResult<List<SupportUser>>> GetAllSupportUsers();
        Task<IResult> CreateSupportUser(SupportUser supportUser, string password);
        Task<IResult> UpdateSupportUser(SupportUser supportUser);
        Task<IResult> DeleteSupportUser(string supportUserId);


    }
}
