using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Stock.GetStockById
{
    public class GetStockByIdQueryHandler : IRequestHandler<GetStockByIdQueryRequest, GetStockByIdQueryResponse>
    {
        private readonly IStockReadRepository _stockReadRepository;

        public GetStockByIdQueryHandler(IStockReadRepository stockReadRepository)
        {
            _stockReadRepository = stockReadRepository;
        }

        public async Task<GetStockByIdQueryResponse> Handle(GetStockByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var stock = await _stockReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                ProductId = stock.ProductId,
                ProductSize = stock.ProductSize,
                ProductStock = stock.ProductStock
            };
        }
    }
}
