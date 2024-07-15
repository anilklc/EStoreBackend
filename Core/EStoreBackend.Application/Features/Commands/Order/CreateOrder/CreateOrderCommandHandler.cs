using EStoreBackend.Application.DTOs;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
           
            await _orderService.CreateOrderAsync(new()
            {
                AddressId = request.AddressId,
                CargoTracking =request.CargoTracking,
                OrderDetails = request.OrderDetails,
                OrderStatus = request.OrderStatus,
                TotalPrice = request.TotalPrice,
                UserName = request.UserName,
            });

            return new CreateOrderCommandResponse();
        }
    }
}
