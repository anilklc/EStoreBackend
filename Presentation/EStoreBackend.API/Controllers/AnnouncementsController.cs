using EStoreBackend.Application.Features.Commands.Announcement.RemoveAnnouncement;
using EStoreBackend.Application.Features.Commands.Announcement.UpdateAnnouncement;
using EStoreBackend.Application.Features.Commands.Announcement.CreateAnnouncement;
using EStoreBackend.Application.Features.Queries.Announcement.GetByIdAnnouncement;
using EStoreBackend.Application.Features.Queries.Announcement.GetAllAnnouncement;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EStoreBackend.API.Helper;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Authorization;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CacheHelper _cacheHelper;

        public AnnouncementsController(IMediator mediator, CacheHelper cacheHelper)
        {
            _mediator = mediator;
            _cacheHelper = cacheHelper;
        }
        [HttpGet("[action]")]
        [OutputCache(PolicyName = "Cache", Tags = ["Announcement"])]

        public async Task<IActionResult> GetAllAnnouncements()
        {
            GetAllAnnouncementQueryResponse response = await _mediator.Send(new GetAllAnnouncementQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        [OutputCache(PolicyName = "Cache", Tags = ["Announcement"])]
        public async Task<IActionResult> GetByIdAnnouncement([FromRoute] GetByIdAnnouncementQueryRequest request)
        {
            GetByIdAnnouncementQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementCommandRequest request)
        {
            CreateAnnouncementCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Announcement");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "EditorOrAdmin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] UpdateAnnouncementCommandRequest request)
        {
            UpdateAnnouncementCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Announcement");
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Admin", Policy = "AdminOnly")]
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveAnnouncement(string Id)
        {
            RemoveAnnouncementCommandRequest request = new RemoveAnnouncementCommandRequest { Id = Id };
            RemoveAnnouncementCommandResponse response = await _mediator.Send(request);
            await _cacheHelper.EvictByTagAsync("Announcement");
            return Ok(response);
        }
    }
}
