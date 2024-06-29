using EStoreBackend.Application.DTOs.Token;
using EStoreBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(AppUser user,IList<string> roles);
        string GenerateRefreshToken();
    }
}
