using Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface InterfaceTokenService
    {

        Task<IDataResult<string>> CreateJwtTokenAsync(IdentityUser user, List<string> roles, bool rememberMe);

        Task<IDataResult<IDictionary<string, string>>> DecodeJwtToken(string token);
    }
}
