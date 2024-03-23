using EStoreBackend.Application.Features.Commands.Policy.CreatePolicy;
using EStoreBackend.Application.Features.Queries.Policy.GetAllPolicy;
using MediatR;
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePolicy([FromQuery] CreatePolicyCommandRequest request)
        {
            CreatePolicyCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
