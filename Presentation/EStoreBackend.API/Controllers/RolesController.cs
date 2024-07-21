using EStoreBackend.Application.Features.Commands.Role;
using EStoreBackend.Application.Features.Commands.User.AddUserRole;
using EStoreBackend.Application.Features.Queries.Role.GetAllRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRole()
        {
            GetAllRoleQueryResponse response = await _mediator.Send(new GetAllRoleQueryRequest());
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest request)
        {
            CreateRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddRoleUser([FromBody] AddUserRoleCommandRequest request)
        {
            AddUserRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
