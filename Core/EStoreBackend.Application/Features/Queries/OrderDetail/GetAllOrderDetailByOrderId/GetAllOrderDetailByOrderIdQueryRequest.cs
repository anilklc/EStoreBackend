using MediatR;

namespace EStoreBackend.Application.Features.Queries.OrderDetail.GetAllOrderDetailByOrderId
{
    public class GetAllOrderDetailByOrderIdQueryRequest : IRequest<GetAllOrderDetailByOrderIdQueryResponse>
    {
        public string Id { get; set; }
    }
}