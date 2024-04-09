using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Announcement.GetAllAnnouncement
{
    public class GetAllAnnouncementQueryHandler : IRequestHandler<GetAllAnnouncementQueryRequest, GetAllAnnouncementQueryResponse>
    {
        private readonly IAnnouncementReadRepository _announcementReadRepository;

        public GetAllAnnouncementQueryHandler(IAnnouncementReadRepository announcementReadRepository)
        {
            _announcementReadRepository = announcementReadRepository;
        }

        public async Task<GetAllAnnouncementQueryResponse> Handle(GetAllAnnouncementQueryRequest request, CancellationToken cancellationToken)
        {
            var announcements = _announcementReadRepository.GetAll().ToList();
            return new()
            {
                Announcements = announcements,
            };
        }
    }
}
