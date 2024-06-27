using EStoreBackend.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.AddUserRole
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommandRequest, AddUserRoleCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public AddUserRoleCommandHandler(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<AddUserRoleCommandResponse> Handle(AddUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            await _userManager.AddToRoleAsync(user,request.Role);
            return new();
        }
    }
}
