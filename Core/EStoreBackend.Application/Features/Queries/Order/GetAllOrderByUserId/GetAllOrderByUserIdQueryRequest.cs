using MediatR;

namespace EStoreBackend.Application.Features.Queries.Order.GetAllOrderByUserId
{
    public class GetAllOrderByUserIdQueryRequest : IRequest<GetAllOrderByUserIdQueryResponse>
    {
        public string Username { get; set; }
        public string? Status { get; set; }
    }
}