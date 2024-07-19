using EStoreBackend.Application.Features.Queries.User.GetUserByUsername;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.User.GetUserByUserId
{
    public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQueryRequest, GetUserByUserIdQueryResponse>
    {
        private readonly IUserService _userService;

        public GetUserByUserIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserByUserIdQueryResponse> Handle(GetUserByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByUserId(request.UserId);
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
