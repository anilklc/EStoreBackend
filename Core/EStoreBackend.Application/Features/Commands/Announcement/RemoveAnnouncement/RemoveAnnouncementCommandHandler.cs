using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Announcement.RemoveAnnouncement
{
    public class RemoveAnnouncementCommandHandler : IRequestHandler<RemoveAnnouncementCommandRequest, RemoveAnnouncementCommandResponse>
    {
        private readonly IAnnouncementWriteRepository _announcementWriteRepository;

        public RemoveAnnouncementCommandHandler(IAnnouncementWriteRepository announcementWriteRepository)
        {
            _announcementWriteRepository = announcementWriteRepository;
        }

        public async Task<RemoveAnnouncementCommandResponse> Handle(RemoveAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            await _announcementWriteRepository.RemoveAsync(request.Id);
            await _announcementWriteRepository.SaveAsync();
            return new();
        }
    }
}
