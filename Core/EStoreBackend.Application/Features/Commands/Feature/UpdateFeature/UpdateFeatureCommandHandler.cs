using EStoreBackend.Application.Features.Commands.Feature.RemoveFeature;
using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Feature.UpdateFeature
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommandRequest, UpdateFeatureCommandResponse>
    {
        private readonly IFeatureReadRepository _featureReadRepository;
        private readonly IFeatureWriteRepository _featureWriteRepository;

        public UpdateFeatureCommandHandler(IFeatureReadRepository featureReadRepository, IFeatureWriteRepository featureWriteRepository)
        {
            _featureReadRepository = featureReadRepository;
            _featureWriteRepository = featureWriteRepository;
        }

        public async Task<UpdateFeatureCommandResponse> Handle(UpdateFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            var feature = await _featureReadRepository.GetByIdAsync(request.Id);
            feature.FeatureName = request.FeatureName;
            feature.FeatureDescription = request.FeatureDescription;
            feature.FeatureIcon = request.FeatureIcon;
            await _featureWriteRepository.SaveAsync();
            return new();
        }
    }
}
