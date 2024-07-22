using EStoreBackend.Application.Exceptions;
using EStoreBackend.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.User.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
    {
        private readonly IUserService _userService;
        public ForgotPasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ForgotPasswordCommandResponse> Handle(ForgotPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            if(!request.Password.Equals(request.PasswordConfirm))
                throw new PasswordChangeException("Password change failed");

            await _userService.ForgotPasswordAsync(request.Id,request.ResetToken,request.Password);
            return new();
        }
    }
}
