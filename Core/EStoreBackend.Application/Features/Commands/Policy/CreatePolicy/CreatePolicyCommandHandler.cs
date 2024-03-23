using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Policy.CreatePolicy
{
    public class CreatePolicyCommandHandler : IRequestHandler<CreatePolicyCommandRequest, CreatePolicyCommandResponse>
    {
        private readonly IPolicyWriteRepository _policyWriteRepository;

        public CreatePolicyCommandHandler(IPolicyWriteRepository policyWriteRepository)
        {
            _policyWriteRepository = policyWriteRepository;
        }

        public async Task<CreatePolicyCommandResponse> Handle(CreatePolicyCommandRequest request, CancellationToken cancellationToken)
        {
            await _policyWriteRepository.AddAsync(new()
            {
                PolicyName = request.PolicyName,
                PolicyDescription = request.PolicyDescription,
                PolicyIcon = request.PolicyIcon,
                PolicyTabHref = request.PolicyTabHref,
            });
            await _policyWriteRepository.SaveAsync();
            return new();
         
        }
    }
}
