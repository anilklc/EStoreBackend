using EStoreBackend.Application.DTOs.Token;

namespace EStoreBackend.Application.Features.Commands.User.LoginAdmin
{
    public class LoginAdminCommandResponse
    {
    }
    public class LoginAdminSuccessCommandResponse : LoginAdminCommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginAdminErrorCommandResponse : LoginAdminCommandResponse
    {
        public string Message { get; set; }
    }
}