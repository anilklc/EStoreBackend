using EStoreBackend.Application.Interfaces.Services;
using EStoreBackend.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.Remove
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, RemoveUserCommandResponse>
    {
       private readonly IUserService _userService;

        public RemoveUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RemoveUserCommandResponse> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthorizedRole.Equals("Admin") && request.Authorized.Equals("admin"))
            {
                await _userService.DeleteUserAsync(request.Id);
                return new();
            }

            throw new Exception("Remove not succesful.");

        }
    }
}
