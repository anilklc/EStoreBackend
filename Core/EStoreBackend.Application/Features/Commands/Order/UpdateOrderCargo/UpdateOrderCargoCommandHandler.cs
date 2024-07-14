using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Order.UpdateOrderCargo
{
    public class UpdateOrderCargoCommandHandler : IRequestHandler<UpdateOrderCargoCommandRequest, UpdateOrderCargoCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public UpdateOrderCargoCommandHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        public async Task<UpdateOrderCargoCommandResponse> Handle(UpdateOrderCargoCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetByIdAsync(request.Id);
            order.CargoTracking = request.CargoTracking;
            await _orderWriteRepository.SaveAsync();
            return new();
        }
    }
}
