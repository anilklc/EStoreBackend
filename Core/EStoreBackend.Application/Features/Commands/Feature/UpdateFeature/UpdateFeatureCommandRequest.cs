using MediatR;

namespace EStoreBackend.Application.Features.Commands.Feature.UpdateFeature
{
    public class UpdateFeatureCommandRequest : IRequest<UpdateFeatureCommandResponse>
    {
        public string Id { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureIcon { get; set; }
    }
}