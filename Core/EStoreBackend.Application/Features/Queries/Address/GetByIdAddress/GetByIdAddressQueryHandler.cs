using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Address.GetByIdAddress
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQueryRequest, GetByIdAddressQueryResponse>
    {
        private readonly IAddressReadRepository _addressReadRepository;
        public GetByIdAddressQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }

        public async Task<GetByIdAddressQueryResponse> Handle(GetByIdAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var address = await _addressReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                FirstName = address.FirstName,
                LastName = address.LastName,
                Phone = address.Phone,
                AddressTitle = address.AddressTitle,
                Country = address.Country,
                City = address.City,
                District = address.District,
                Detail = address.Detail
            };
        }
    }
}
