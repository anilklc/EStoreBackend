using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Feature.CreateFeature
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommandRequest, CreateFeatureCommandResponse>
    {
        private readonly IFeatureWriteRepository _featureWriteRepository;

        public CreateFeatureCommandHandler(IFeatureWriteRepository featureWriteRepository)
        {
            _featureWriteRepository = featureWriteRepository;
        }

        public async Task<CreateFeatureCommandResponse> Handle(CreateFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            await _featureWriteRepository.AddAsync(new()
            {
                FeatureName = request.FeatureName,
                FeatureDescription = request.FeatureDescription,
                FeatureIcon = request.FeatureIcon,
            });
            await _featureWriteRepository.SaveAsync();
            return new();
        }
    }
}
