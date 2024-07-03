using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.Logout
{
    public class LogoutCommandRequest : IRequest<LogoutCommandResponse>
    {
        public string userName { get; set; }
    }
}