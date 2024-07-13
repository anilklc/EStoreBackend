using EStoreBackend.Domain.Entities;
using MediatR;

namespace EStoreBackend.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public DTOs.CreateOrder CreateOrder { get; set; }
    }
}