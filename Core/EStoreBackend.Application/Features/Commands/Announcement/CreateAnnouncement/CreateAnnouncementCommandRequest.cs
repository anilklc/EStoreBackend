using MediatR;

namespace EStoreBackend.Application.Features.Commands.Announcement.CreateAnnouncement
{
    public class CreateAnnouncementCommandRequest : IRequest<CreateAnnouncementCommandResponse>
    {
        public string Title { get; set; }
    }
}