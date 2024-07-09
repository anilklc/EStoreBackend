using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Address.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IAddressWriteRepository _addressWriteRepository;
        public CreateAddressCommandHandler(IUserService userService, IAddressWriteRepository addressWriteRepository)
        {
            _userService = userService;
            _addressWriteRepository = addressWriteRepository;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByUsernameAsync(request.UserName);
            await _addressWriteRepository.AddAsync(new()
            {
                UserId = user.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                AdressTitle = request.AdressTitle,
                Country = request.Country,
                City = request.City,
                District = request.District,
                Detail = request.Detail  
            });
            await _addressWriteRepository.SaveAsync();
            return new();
        }
    }
}
