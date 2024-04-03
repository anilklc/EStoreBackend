using MediatR;

namespace EStoreBackend.Application.Features.Commands.Feature.CreateFeature
{
    public class CreateFeatureCommandRequest : IRequest<CreateFeatureCommandResponse>
    {
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureIcon { get; set; }
    }
}