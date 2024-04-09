using EStoreBackend.Application.Features.Commands.Announcement.RemoveAnnouncement;
using EStoreBackend.Application.Features.Commands.Announcement.UpdateAnnouncement;
using EStoreBackend.Application.Features.Commands.Announcement.CreateAnnouncement;
using EStoreBackend.Application.Features.Queries.Announcement.GetByIdAnnouncement;
using EStoreBackend.Application.Features.Queries.Announcement.GetAllAnnouncement;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EStoreBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnnouncementsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAnnouncements()
        {
            GetAllAnnouncementQueryResponse response = await _mediator.Send(new GetAllAnnouncementQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdAnnouncement([FromRoute] GetByIdAnnouncementQueryRequest request)
        {
            GetByIdAnnouncementQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementCommandRequest request)
        {
            CreateAnnouncementCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] UpdateAnnouncementCommandRequest request)
        {
            UpdateAnnouncementCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveAnnouncement(string Id)
        {
            RemoveAnnouncementCommandRequest request = new RemoveAnnouncementCommandRequest { Id = Id };
            RemoveAnnouncementCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
