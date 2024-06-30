using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var roleController = await _authService.RoleControl(request.Email);
            if (roleController.Any(r => r == "User"))
            {

                var token = await _authService.LoginAsync(request.Email, request.Password);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token,
                };
            }

            else
            {
                return new LoginUserErrorCommandResponse()
                {
                    Message = "unauthorized area entry"
                };
            }
        }
    }
}
