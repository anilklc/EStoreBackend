using MediatR;

namespace EStoreBackend.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryRequest : IRequest<GetAllOrderQueryResponse>
    {
        public string? Status { get; set; }
    }
}