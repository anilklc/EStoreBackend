using MediatR;

namespace EStoreBackend.Application.Features.Queries.Announcement.GetByIdAnnouncement
{
    public class GetByIdAnnouncementQueryRequest : IRequest<GetByIdAnnouncementQueryResponse>
    {
        public string Id { get; set; }
    }
}