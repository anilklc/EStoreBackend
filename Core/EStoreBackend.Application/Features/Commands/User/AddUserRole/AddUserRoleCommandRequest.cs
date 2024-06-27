using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.AddUserRole
{
    public class AddUserRoleCommandRequest : IRequest<AddUserRoleCommandResponse>
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }
}