using MediatR;

namespace EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageById
{
    public class GetBrandImageByIdQueryRequest : IRequest<GetBrandImageByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}