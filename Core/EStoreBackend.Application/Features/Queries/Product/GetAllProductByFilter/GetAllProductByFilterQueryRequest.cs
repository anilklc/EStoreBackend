using MediatR;

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProductByFilter
{
    public class GetAllProductByFilterQueryRequest : IRequest<GetAllProductByFilterQueryResponse>
    {
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public float? MaxPrice { get; set; }
        public float? MinPrice { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 9;
    }
}