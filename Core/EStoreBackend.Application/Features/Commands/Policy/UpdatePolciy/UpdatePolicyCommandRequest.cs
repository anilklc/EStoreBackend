using MediatR;

namespace EStoreBackend.Application.Features.Commands.Policy.UpdatePolciy
{
    public class UpdatePolicyCommandRequest : IRequest<UpdatePolicyCommandResponse>
    {
        public string Id { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public string PolicyIcon { get; set; }
        public string PolicyTabHref { get; set; }
    }
}