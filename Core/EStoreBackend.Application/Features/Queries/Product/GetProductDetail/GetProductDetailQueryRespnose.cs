using EStoreBackend.Application.DTOs.Product;

namespace EStoreBackend.Application.Features.Queries.Product.GetProductDetail
{
    public class GetProductDetailQueryRespnose
    {
        public List<ProductDetailDto> ProductDetail { get; set; }
    }
}