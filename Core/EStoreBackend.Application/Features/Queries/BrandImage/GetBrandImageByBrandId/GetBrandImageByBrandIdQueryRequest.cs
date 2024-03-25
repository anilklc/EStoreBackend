using MediatR;

namespace EStoreBackend.Application.Features.Queries.BrandImage.GetBrandImageByBrandId
{
    public class GetBrandImageByBrandIdQueryRequest : IRequest<GetBrandImageByBrandIdQueryResponse>
    {
        public string BrandId { get; set; }
    }
}