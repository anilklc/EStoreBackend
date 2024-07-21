using EStoreBackend.Application.Features.Commands.Policy.CreatePolicy;
using EStoreBackend.Application.Features.Commands.Policy.RemovePolicy;
using EStoreBackend.Application.Features.Commands.Policy.UpdatePolciy;
using EStoreBackend.Application.Features.Queries.Policy.GetAllPolicy;
using EStoreBackend.Application.Features.Queries.Policy.GetByIdPolicy;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PoliciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPolicies()
        {
            GetAllPolicyQueryResponse response = await _mediator.Send(new GetAllPolicyQueryRequest()); 
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdPolicy([FromRoute] GetByIdPolicyQueryRequest request)
        {
            GetByIdPolicyQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePolicy([FromBody] CreatePolicyCommandRequest request)
        {
            CreatePolicyCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePolicy([FromBody] UpdatePolicyCommandRequest request)
        {
            UpdatePolicyCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemovePolicy(string Id)
        {
            RemovePolicyCommandRequest request = new RemovePolicyCommandRequest { Id = Id };
            RemovePolicyCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
