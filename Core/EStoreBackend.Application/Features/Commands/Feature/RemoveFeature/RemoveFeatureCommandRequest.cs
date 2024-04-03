using MediatR;

namespace EStoreBackend.Application.Features.Commands.Feature.RemoveFeature
{
    public class RemoveFeatureCommandRequest : IRequest<RemoveFeatureCommandResponse>
    {
        public string Id { get; set; }
    }
}