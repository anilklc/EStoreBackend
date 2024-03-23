using MediatR;

namespace EStoreBackend.Application.Features.Commands.Policy.CreatePolicy
{
    public class CreatePolicyCommandRequest : IRequest<CreatePolicyCommandResponse>
    {
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public string PolicyIcon { get; set; }
        public string PolicyTabHref { get; set; }
    }
}