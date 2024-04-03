using MediatR;

namespace EStoreBackend.Application.Features.Queries.Feature.GetByIdFeature
{
    public class GetByIdFeatureQueryRequest : IRequest<GetByIdFeatureQueryResponse>
    {
        public string Id { get; set; }
    }
}