using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.OrderDetail.GetAllOrderDetailByOrderId
{
    public class GetAllOrderDetailByOrderIdQueryHandler : IRequestHandler<GetAllOrderDetailByOrderIdQueryRequest, GetAllOrderDetailByOrderIdQueryResponse>
    {
        private readonly IOrderDetailReadRepository _orderDetailReadRepository;
        public GetAllOrderDetailByOrderIdQueryHandler(IOrderDetailReadRepository orderDetailReadRepository)
        {
            _orderDetailReadRepository = orderDetailReadRepository;
        }

        public async Task<GetAllOrderDetailByOrderIdQueryResponse> Handle(GetAllOrderDetailByOrderIdQueryRequest request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailReadRepository.GetWhere(o => o.Order.Id == Guid.Parse(request.Id)).ToListAsync();
            return new()
            {
                OrderDetails = orderDetails,
            };
        }
    }
}
