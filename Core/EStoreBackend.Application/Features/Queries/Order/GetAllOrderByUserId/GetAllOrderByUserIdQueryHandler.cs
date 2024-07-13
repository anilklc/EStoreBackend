using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Order.GetAllOrderByUserId
{
    public class GetAllOrderByUserIdQueryHandler : IRequestHandler<GetAllOrderByUserIdQueryRequest, GetAllOrderByUserIdQueryResponse>
    {
        private readonly IOrderService _orderService;

        public GetAllOrderByUserIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetAllOrderByUserIdQueryResponse> Handle(GetAllOrderByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderService.GetAllOrderByUserId(request.Username,request.Status);
            return new()
            {
                Orders = orders
            };
        }
    }
}
