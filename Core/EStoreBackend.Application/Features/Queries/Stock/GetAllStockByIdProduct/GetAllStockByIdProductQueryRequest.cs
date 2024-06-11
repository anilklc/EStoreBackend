using MediatR;

namespace EStoreBackend.Application.Features.Queries.Stock.GetAllStockByIdProduct
{
    public class GetAllStockByIdProductQueryRequest : IRequest<GetAllStockByIdProductQueryResponse>
    {
        public string ProductId { get; set; }
    }
}