using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Feature.RemoveFeature
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommandRequest, RemoveFeatureCommandResponse>
    {
        private readonly IFeatureWriteRepository _featureWriteRepository;

        public RemoveFeatureCommandHandler(IFeatureWriteRepository featureWriteRepository)
        {
            _featureWriteRepository = featureWriteRepository;
        }

        public async Task<RemoveFeatureCommandResponse> Handle(RemoveFeatureCommandRequest request, CancellationToken cancellationToken)
        {
            await _featureWriteRepository.RemoveAsync(request.Id);
            await _featureWriteRepository.SaveAsync();
            return new();
        }
    }
}
