using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Announcement.CreateAnnouncement
{
    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommandRequest, CreateAnnouncementCommandResponse>
    {
        private readonly IAnnouncementWriteRepository _announcementWriteRepository;

        public CreateAnnouncementCommandHandler(IAnnouncementWriteRepository announcementWriteRepository)
        {
            _announcementWriteRepository = announcementWriteRepository;
        }

        public async Task<CreateAnnouncementCommandResponse> Handle(CreateAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            await _announcementWriteRepository.AddAsync(new() { Title = request.Title});
            await _announcementWriteRepository.SaveAsync();
            return new();
        }
    }
}
