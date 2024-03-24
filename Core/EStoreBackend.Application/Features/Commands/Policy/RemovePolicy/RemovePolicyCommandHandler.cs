using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Policy.RemovePolicy
{
    public class RemovePolicyCommandHandler : IRequestHandler<RemovePolicyCommandRequest, RemovePolicyCommandResponse>
    {
        private readonly IPolicyWriteRepository _policyWriteRepository;

        public RemovePolicyCommandHandler(IPolicyWriteRepository policyWriteRepository)
        {
            _policyWriteRepository = policyWriteRepository;
        }

        public async Task<RemovePolicyCommandResponse> Handle(RemovePolicyCommandRequest request, CancellationToken cancellationToken)
        {
            await _policyWriteRepository.RemoveAsync(request.Id);
            await _policyWriteRepository.SaveAsync();
            return new();
        }
    }
}
