using MediatR;

namespace EStoreBackend.Application.Features.Queries.ProductImage.GetProductImageById
{
    public class GetProductImageByIdQueryRequest : IRequest<GetProductImageByIdQueryResponse>   
    {
        public string Id { get; set; }

    }
}