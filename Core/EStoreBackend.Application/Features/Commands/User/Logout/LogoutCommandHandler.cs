using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommandRequest, LogoutCommandResponse>
    {
        private readonly IAuthService _authService;

        public LogoutCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LogoutCommandResponse> Handle(LogoutCommandRequest request, CancellationToken cancellationToken)
        {
            await _authService.Logout(request.userName);
            return new();
        }
    }
}
