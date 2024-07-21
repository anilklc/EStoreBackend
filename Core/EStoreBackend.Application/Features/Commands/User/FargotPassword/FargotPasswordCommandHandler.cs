using EStoreBackend.Application.Exceptions;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.FargotPassword
{
    public class FargotPasswordCommandHandler : IRequestHandler<FargotPasswordCommandRequest, FargotPasswordCommandResponse>
    {
        private readonly IUserService _userService;
        public FargotPasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<FargotPasswordCommandResponse> Handle(FargotPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if(!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeException("Password change failed");

            await _userService.FargotPasswordAsync(request.Id,request.ResetToken,request.Password);
            return new();
        }
    }
}
