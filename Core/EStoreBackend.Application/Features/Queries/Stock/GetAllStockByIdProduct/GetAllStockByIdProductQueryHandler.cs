using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Stock.GetAllStockByIdProduct
{
    public class GetAllStockByIdProductQueryHandler : IRequestHandler<GetAllStockByIdProductQueryRequest, GetAllStockByIdProductQueryResponse>
    {
        private readonly IStockReadRepository _stockReadRepository;

        public GetAllStockByIdProductQueryHandler(IStockReadRepository stockReadRepository)
        {
            _stockReadRepository = stockReadRepository;
        }

        public async Task<GetAllStockByIdProductQueryResponse> Handle(GetAllStockByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var stocks =  _stockReadRepository.GetWhere(s=>s.ProductId == Guid.Parse(request.ProductId)).ToList();
            return new()
            { 
                Stocks = stocks 
            };
        }
    }
}
