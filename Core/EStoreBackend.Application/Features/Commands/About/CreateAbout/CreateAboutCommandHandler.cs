using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.About.CreateAbout
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommandRequest, CreateAboutCommandResponse>
    {
        private readonly IAboutWriteRepository _aboutWriteRepository;

        public CreateAboutCommandHandler(IAboutWriteRepository aboutWriteRepository)
        {
            _aboutWriteRepository = aboutWriteRepository;
        }

        public async Task<CreateAboutCommandResponse> Handle(CreateAboutCommandRequest request, CancellationToken cancellationToken)
        {
            await _aboutWriteRepository.AddAsync(new()
            {
                AboutTitle = request.AboutTitle,
                AboutDescription = request.AboutDescription,
                AboutIcon = request.AboutIcon,
            });
            await _aboutWriteRepository.SaveAsync();
            return new();
        }
    }
}
