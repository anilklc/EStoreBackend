using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Stock.RemoveStock
{
    public class RemoveStockCommandHandler : IRequestHandler<RemoveStockCommandRequest, RemoveStockCommandResponse>
    {
        private readonly IStockWriteRepository _stockWriteRepository;
        public RemoveStockCommandHandler(IStockWriteRepository stockWriteRepository)
        {
            _stockWriteRepository = stockWriteRepository;
        }

        public async Task<RemoveStockCommandResponse> Handle(RemoveStockCommandRequest request, CancellationToken cancellationToken)
        {
            await _stockWriteRepository.RemoveAsync(request.Id);
            await _stockWriteRepository.SaveAsync();
            return new();
        }
    }
}
