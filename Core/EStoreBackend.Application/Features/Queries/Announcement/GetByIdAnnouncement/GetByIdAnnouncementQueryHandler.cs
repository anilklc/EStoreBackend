using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Announcement.GetByIdAnnouncement
{
    public class GetByIdAnnouncementQueryHandler : IRequestHandler<GetByIdAnnouncementQueryRequest, GetByIdAnnouncementQueryResponse>
    {
        private readonly IAnnouncementReadRepository _announcementReadRepository;

        public GetByIdAnnouncementQueryHandler(IAnnouncementReadRepository announcementReadRepository)
        {
            _announcementReadRepository = announcementReadRepository;
        }

        public async Task<GetByIdAnnouncementQueryResponse> Handle(GetByIdAnnouncementQueryRequest request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                Title = announcement.Title,
            };
        }
    }
}
