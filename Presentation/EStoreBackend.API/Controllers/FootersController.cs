using EStoreBackend.Application.Features.Commands.Footer.CreateFooter;
using EStoreBackend.Application.Features.Commands.Footer.RemoveFooter;
using EStoreBackend.Application.Features.Commands.Footer.UpdateFooter;
using EStoreBackend.Application.Features.Queries.Footer.GetAllFooter;
using EStoreBackend.Application.Features.Queries.Footer.GetByIdFooter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FootersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFooters()
        {
            GetAllFooterQueryResponse response = await _mediator.Send(new GetAllFooterQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdFooter([FromRoute] GetByIdFooterQueryRequest request)
        {
            GetByIdFooterQueryRespnose response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateFooter([FromBody] CreateFooterCommandRequest request)
        {
            CreateFooterCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateFooter([FromBody] UpdateFooterCommandRequest request)
        {
            UpdateFooterCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveFooter(string Id)
        {
            RemoveFooterCommandRequest request = new RemoveFooterCommandRequest { Id = Id };
            RemoveFooterCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
