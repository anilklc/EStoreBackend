using MediatR;

namespace EStoreBackend.Application.Features.Commands.Stock.UpdateStock
{
    public class UpdateStockCommandRequest : IRequest<UpdateStockCommandResponse>
    {
        public string Id { get; set; }
        public string ProductSize { get; set; }
        public int ProductStock { get; set; }
    }
}