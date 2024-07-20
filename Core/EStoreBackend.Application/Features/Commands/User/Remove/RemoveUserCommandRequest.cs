using MediatR;

namespace EStoreBackend.Application.Features.Commands.User.Remove
{
    public class RemoveUserCommandRequest : IRequest<RemoveUserCommandResponse>
    {
        public string Id { get; set; }
        public string AuthorizedRole { get; set; }
        public string Authorized { get; set; }

    }
}