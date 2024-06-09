using MediatR;

namespace EStoreBackend.Application.Features.Queries.ProductImage.GetProductImageByProductId
{
    public class GetProductImageByProductIdQueryRequest : IRequest<GetProductImageByProductIdQueryResponse>
    {
        public string ProductId { get; set; }
    }
}