using MediatR;

namespace EStoreBackend.Application.Features.Commands.Policy.RemovePolicy
{
    public class RemovePolicyCommandRequest : IRequest<RemovePolicyCommandResponse>
    {
        public string Id { get; set; }
    }
}