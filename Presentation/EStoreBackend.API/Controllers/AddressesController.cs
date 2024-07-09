using EStoreBackend.Application.Features.Commands.Address.CreateAddress;
using EStoreBackend.Application.Features.Commands.Address.RemoveAddress;
using EStoreBackend.Application.Features.Commands.Address.UpdateAddress;
using EStoreBackend.Application.Features.Queries.Address.GetAddressByUsername;
using EStoreBackend.Application.Features.Queries.Address.GetByIdAddress;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdAddress([FromRoute] GetByIdAddressQueryRequest request)
        {
            GetByIdAddressQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAddressByUsername([FromRoute] GetAddressByUsernameQueryRequest request)
        {
            GetAddressByUsernameQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommandRequest request)
        {
            CreateAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressCommandRequest request)
        {
            UpdateAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveAddress(string Id)
        {
            RemoveAddressCommandRequest request = new RemoveAddressCommandRequest { Id = Id };
            RemoveAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
