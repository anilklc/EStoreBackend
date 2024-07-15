using EStoreBackend.Application.DTOs.Order;
using EStoreBackend.Domain.Entities;
using MediatR;

namespace EStoreBackend.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string AddressId { get; set; }
        public string CargoTracking { get; set; } = String.Empty;
        public List<OrderDetails> OrderDetails { get; set; }
    }
}