using MediatR;

namespace EStoreBackend.Application.Features.Commands.Announcement.UpdateAnnouncement
{
    public class UpdateAnnouncementCommandRequest : IRequest<UpdateAnnouncementCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}