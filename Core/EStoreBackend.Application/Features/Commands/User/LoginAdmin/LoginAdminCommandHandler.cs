using EStoreBackend.Application.Features.Commands.User.LoginUser;
using EStoreBackend.Application.Interfaces.Services;
using EStoreBackend.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.LoginAdmin
{
    public class LoginAdminCommandHandler : IRequestHandler<LoginAdminCommandRequest, LoginAdminCommandResponse>
    {
        private readonly IAuthService _authService;
        public LoginAdminCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginAdminCommandResponse> Handle(LoginAdminCommandRequest request, CancellationToken cancellationToken)
        {
            var roleControl = await _authService.RoleControl(request.Email);
            if (roleControl.Any(r => r == "Admin" || r == "Editör"))
            {
                var token = await _authService.LoginAsync(request.Email, request.Password);
                return new LoginAdminSuccessCommandResponse()
                {
                    Token = token,
                };
            }
            else 
            {
                return new LoginAdminErrorCommandResponse()
                {
                    Message = "entrance to unauthorized area"
                };
            }
        }
    }
}
