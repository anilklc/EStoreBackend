using MediatR;

namespace EStoreBackend.Application.Features.Queries.Stock.GetStockById
{
    public class GetStockByIdQueryRequest : IRequest<GetStockByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}