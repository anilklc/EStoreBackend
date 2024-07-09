using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.User.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQueryRequest, GetUserByUsernameQueryResponse>
    {
        private readonly IUserService _userService;

        public GetUserByUsernameQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserByUsernameQueryResponse> Handle(GetUserByUsernameQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByUsernameAsync(request.UserName);
            return new(){ 
                Id = user.Id.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
            };
        }
    }
}
