using MediatR;

namespace EStoreBackend.Application.Features.Commands.Announcement.RemoveAnnouncement
{
    public class RemoveAnnouncementCommandRequest : IRequest<RemoveAnnouncementCommandResponse>
    {
        public string Id { get; set; }
    }
}