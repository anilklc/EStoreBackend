using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Order.UpdateOrderStatus
{
    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommandRequest, UpdateOrderStatusCommandResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;
        public UpdateOrderStatusCommandHandler(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<UpdateOrderStatusCommandResponse> Handle(UpdateOrderStatusCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetByIdAsync(request.Id);
            order.OrderStatus = request.OrderStatus;
            await _orderWriteRepository.SaveAsync();
            return new();

        }
    }
}
