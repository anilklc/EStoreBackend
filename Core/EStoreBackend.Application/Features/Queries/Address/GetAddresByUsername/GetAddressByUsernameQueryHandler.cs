using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Address.GetAddressByUsername
{
    public class GetAddressByUsernameQueryHandler : IRequestHandler<GetAddressByUsernameQueryRequest, GetAddressByUsernameQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IAddressReadRepository _addressReadRepository;
        public GetAddressByUsernameQueryHandler(IUserService userService, IAddressReadRepository addressReadRepository)
        {
            _userService = userService;
            _addressReadRepository = addressReadRepository;
        }

        public async Task<GetAddressByUsernameQueryResponse> Handle(GetAddressByUsernameQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByUsernameAsync(request.userName);
            var address =  _addressReadRepository.GetWhere(a=>a.UserId== user.Id).ToList();
            return new() 
            { 
                Address = address
            };
        }
    }
}
