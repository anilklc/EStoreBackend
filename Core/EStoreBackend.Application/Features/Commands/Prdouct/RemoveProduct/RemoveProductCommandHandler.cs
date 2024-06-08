using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Prdouct.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IStockWriteRepository _stockWriteRepository;
        private readonly IStockReadRepository _stockReadRepository;

        public RemoveProductCommandHandler(IProductWriteRepository productWriteRepository, IStockWriteRepository stockWriteRepository, IStockReadRepository stockReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _stockWriteRepository = stockWriteRepository;
            _stockReadRepository = stockReadRepository;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            var stock = _stockReadRepository.GetWhere(s => s.ProductId == Guid.Parse(request.Id)).ToList();
            if (stock.Any())
            {
                _stockWriteRepository.RemoveRange(stock);
            }
            await _productWriteRepository.SaveAsync();
            await _stockWriteRepository.SaveAsync();
            return new();
        }
    }
}
