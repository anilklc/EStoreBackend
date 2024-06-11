using MediatR;

namespace EStoreBackend.Application.Features.Commands.Stock.RemoveStock
{
    public class RemoveStockCommandRequest : IRequest<RemoveStockCommandResponse>
    {
        public string Id { get; set; }
    }
}