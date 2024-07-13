using MediatR;

namespace EStoreBackend.Application.Features.Commands.Order.UpdateOrderStatus
{
    public class UpdateOrderStatusCommandRequest : IRequest<UpdateOrderStatusCommandResponse>
    {
        public string Id { get; set; }
        public string OrderStatus { get; set; }
    }
}