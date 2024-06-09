using EStoreBackend.Application.DTOs.ProductImage;

namespace EStoreBackend.Application.Features.Queries.ProductImage.GetProductImageByProductId
{
    public class GetProductImageByProductIdQueryResponse
    {
        public List<ListProductImage> ProductImages { get; set; }
    }
}