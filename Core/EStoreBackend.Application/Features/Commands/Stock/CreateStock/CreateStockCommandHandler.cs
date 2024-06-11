using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Stock.CreateStock
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, CreateStockCommandResponse>
    {
        private readonly IStockWriteRepository _stockWriteRepository;

        public CreateStockCommandHandler(IStockWriteRepository stockWriteRepository)
        {
            _stockWriteRepository = stockWriteRepository;
        }

        public async Task<CreateStockCommandResponse> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
        {
            await _stockWriteRepository.AddAsync(new()
            {
                ProductSize = request.ProductSize,
                ProductId = request.ProductId,
                ProductStock = request.ProductStock,
            });
            await _stockWriteRepository.SaveAsync();
            return new();
        }
    }
}
