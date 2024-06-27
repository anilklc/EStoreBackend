using MediatR;

namespace EStoreBackend.Application.Features.Commands.Role
{
    public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
    {
        public string Role { get; set; }

    }
}