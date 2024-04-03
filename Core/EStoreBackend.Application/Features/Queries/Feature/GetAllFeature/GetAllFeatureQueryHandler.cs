using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Feature.GetAllFeature
{
    public class GetAllFeatureQueryHandler : IRequestHandler<GetAllFeatureQueryRequest, GetAllFeatureQueryResponse>
    {
        private readonly IFeatureReadRepository _featureReadRepository;

        public GetAllFeatureQueryHandler(IFeatureReadRepository featureReadRepository)
        {
            _featureReadRepository = featureReadRepository;
        }

        public async Task<GetAllFeatureQueryResponse> Handle(GetAllFeatureQueryRequest request, CancellationToken cancellationToken)
        {
            var features = _featureReadRepository.GetAll().ToList();
            return new()
            {
                Features = features,
            };
        }
    }
}
