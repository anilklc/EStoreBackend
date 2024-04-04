using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Footer.RemoveFooter
{
    public class RemoveFooterCommandHandler : IRequestHandler<RemoveFooterCommandRequest, RemoveFooterCommandResponse>
    {
        private readonly IFeatureWriteRepository _featureWriteRepository;

        public RemoveFooterCommandHandler(IFeatureWriteRepository featureWriteRepository)
        {
            _featureWriteRepository = featureWriteRepository;
        }

        public async Task<RemoveFooterCommandResponse> Handle(RemoveFooterCommandRequest request, CancellationToken cancellationToken)
        {
            await _featureWriteRepository.RemoveAsync(request.Id);
            await _featureWriteRepository.SaveAsync();
            return new();
        }
    }
}
