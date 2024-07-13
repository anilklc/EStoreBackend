using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        private readonly IOrderService _orderService;

        public GetAllOrderQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = _orderService.GetAllOrder(request.Status);
            return new()
            {
                Orders = orders,
            };
        }
    }
}
