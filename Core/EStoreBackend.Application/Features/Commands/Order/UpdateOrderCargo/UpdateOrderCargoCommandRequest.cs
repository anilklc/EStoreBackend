using MediatR;

namespace EStoreBackend.Application.Features.Commands.Order.UpdateOrderCargo
{
    public class UpdateOrderCargoCommandRequest : IRequest<UpdateOrderCargoCommandResponse>
    {
        public string Id { get; set; }
        public string CargoTracking { get; set; }
    }
}