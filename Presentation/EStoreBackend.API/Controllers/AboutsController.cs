using EStoreBackend.API.Helper;
using EStoreBackend.Application.Features.Commands.About.CreateAbout;
using EStoreBackend.Application.Features.Commands.About.RemoveAbout;
using EStoreBackend.Application.Features.Commands.About.UpdateAbout;
using EStoreBackend.Application.Features.Queries.About.GetAllAbout;
using EStoreBackend.Application.Features.Queries.About.GetByIdAbout;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;
        public AboutsController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }

        [HttpGet("[action]")]
        [OutputCache(PolicyName ="Cache", Tags = ["About"])]
        public async Task<IActionResult> GetAllAbouts()
        {
            GetAllAboutQueryResponse response = await _mediator.Send(new GetAllAboutQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        [OutputCache(PolicyName = "Cache",Tags =["About"])]
        public async Task<IActionResult> GetByIdAbout([FromRoute] GetByIdAboutQueryRequest request)
        {
            GetByIdAboutQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutCommandRequest request)
        {
            CreateAboutCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("About");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutCommandRequest request)
        {
            UpdateAboutCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("About");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveAbout(string Id)
        {
            RemoveAboutCommandRequest request = new RemoveAboutCommandRequest { Id = Id };
            RemoveAboutCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("About");
            return Ok(response);
        }
    }
}
