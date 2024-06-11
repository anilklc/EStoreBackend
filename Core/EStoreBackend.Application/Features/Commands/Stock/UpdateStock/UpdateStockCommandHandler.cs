using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Stock.UpdateStock
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommandRequest, UpdateStockCommandResponse>
    {
        private readonly IStockReadRepository _stockReadRepository;
        private readonly IStockWriteRepository _stockWriteRepository;
        public UpdateStockCommandHandler(IStockReadRepository stockReadRepository, IStockWriteRepository stockWriteRepository)
        {
            _stockReadRepository = stockReadRepository;
            _stockWriteRepository = stockWriteRepository;
        }

        public async Task<UpdateStockCommandResponse> Handle(UpdateStockCommandRequest request, CancellationToken cancellationToken)
        {
            var stock = await _stockReadRepository.GetByIdAsync(request.Id);
            stock.ProductStock = request.ProductStock;
            stock.ProductSize = request.ProductSize;
            await _stockWriteRepository.SaveAsync();
            return new();
        }
    }
}
