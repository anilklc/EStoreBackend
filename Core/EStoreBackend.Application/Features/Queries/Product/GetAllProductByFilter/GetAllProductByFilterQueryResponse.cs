using EStoreBackend.Application.DTOs.Product;

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProductByFilter
{
    public class GetAllProductByFilterQueryResponse
    {
        public List<GetAllProductDto> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}