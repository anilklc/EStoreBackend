using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IAddressWriteRepository _addressWriteRepository;
        private readonly IAddressReadRepository _addressReadRepository;

        public UpdateAddressCommandHandler(IAddressWriteRepository addressWriteRepository, IAddressReadRepository addressReadRepository)
        {
            _addressWriteRepository = addressWriteRepository;
            _addressReadRepository = addressReadRepository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
           var address = await _addressReadRepository.GetByIdAsync(request.Id);
            address.FirstName = request.FirstName;
            address.LastName = request.LastName;
            address.Phone = request.Phone;
            address.AdressTitle = request.AdressTitle;
            address.Country = request.Country;
            address.City = request.City;
            address.District = request.District;
            address.Detail = request.Detail;
            await _addressWriteRepository.SaveAsync();
            return new();
        }
    }
}
