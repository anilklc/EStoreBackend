using EStoreBackend.Application.DTOs.Token;

namespace EStoreBackend.Application.Features.Commands.User.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public Token Token { get; set; }
    }
}