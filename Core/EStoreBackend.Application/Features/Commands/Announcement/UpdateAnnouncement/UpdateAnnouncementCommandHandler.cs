using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Announcement.UpdateAnnouncement
{
    public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommandRequest, UpdateAnnouncementCommandResponse>
    {
        private readonly IAnnouncementReadRepository _announcementReadRepository;
        private readonly IAnnouncementWriteRepository _announcementWriteRepository;

        public UpdateAnnouncementCommandHandler(IAnnouncementReadRepository announcementReadRepository, IAnnouncementWriteRepository announcementWriteRepository)
        {
            _announcementReadRepository = announcementReadRepository;
            _announcementWriteRepository = announcementWriteRepository;
        }

        public async Task<UpdateAnnouncementCommandResponse> Handle(UpdateAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementReadRepository.GetByIdAsync(request.Id);
            announcement.Title = request.Title;
            await _announcementWriteRepository.SaveAsync();
            return new();
        }
    }
}
