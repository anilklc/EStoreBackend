using EStoreBackend.Application.Features.Commands.Prdouct.RemoveProduct;
using EStoreBackend.Application.Features.Commands.User.CreateUser;
using EStoreBackend.Application.Features.Commands.User.CreateUserAdmin;
using EStoreBackend.Application.Features.Commands.User.Remove;
using EStoreBackend.Application.Features.Commands.User.UpdatePassword;
using EStoreBackend.Application.Features.Queries.Brand.GetByIdBrand;
using EStoreBackend.Application.Features.Queries.User;
using EStoreBackend.Application.Features.Queries.User.GetUserByUserId;
using EStoreBackend.Application.Features.Queries.User.GetUserByUsername;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUserAdmin(CreateUserAdminCommandRequest createUserAdminCommandRequest)
        {
            CreateUserAdminCommandResponse response = await _mediator.Send(createUserAdminCommandRequest);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "All")]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            GetAllUsersQueryResponse response = await _mediator.Send(new GetAllUsersQueryRequest());
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpGet("[action]/{UserId}")]
        public async Task<IActionResult> GetUserByUserId([FromRoute] GetUserByUserIdQueryRequest request)
        {
            GetUserByUserIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}/{AuthorizedRole}/{Authorized}")]
        public async Task<IActionResult> RemoveUser([FromRoute] RemoveUserCommandRequest request)
        {
            RemoveUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
