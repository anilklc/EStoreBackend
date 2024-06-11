using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProductByFilter
{
    public class GetAllProductByFilterQueryHandler : IRequestHandler<GetAllProductByFilterQueryRequest, GetAllProductByFilterQueryResponse>
    {

        public Task<GetAllProductByFilterQueryResponse> Handle(GetAllProductByFilterQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
