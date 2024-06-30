using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.LoginAdmin
{
    public class LoginAdminCommandRequest : IRequest<LoginAdminCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}