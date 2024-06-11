using MediatR;

namespace EStoreBackend.Application.Features.Commands.Stock.CreateStock
{
    public class CreateStockCommandRequest : IRequest<CreateStockCommandResponse>
    {
        public string ProductSize { get; set; }
        public int ProductStock { get; set; }
        public Guid ProductId { get; set; }
    }
}