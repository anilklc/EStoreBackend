using EStoreBackend.Application.Features.Commands.User.FargotPassword;
using EStoreBackend.Application.Features.Commands.User.LoginAdmin;
using EStoreBackend.Application.Features.Commands.User.LoginUser;
using EStoreBackend.Application.Features.Commands.User.Logout;
using EStoreBackend.Application.Features.Commands.User.PasswordReset;
using EStoreBackend.Application.Features.Commands.User.RefreshTokenLogin;
using EStoreBackend.Application.Features.Commands.User.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginAdminCommandRequest loginAdminCommandRequest)
        {
            LoginAdminCommandResponse response = await _mediator.Send(loginAdminCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Logout([FromBody] LogoutCommandRequest logoutCommandRequest)
        {
            LogoutCommandResponse response = await _mediator.Send(logoutCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
        {
            PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FargotPassword([FromBody] FargotPasswordCommandRequest fargotPasswordCommandRequest)
        {
            FargotPasswordCommandResponse response = await _mediator.Send(fargotPasswordCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]      
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
        {
            VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
            return Ok(response);
        }
    }
}
