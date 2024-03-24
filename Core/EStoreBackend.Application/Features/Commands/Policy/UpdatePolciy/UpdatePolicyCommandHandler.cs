using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Policy.UpdatePolciy
{
    public class UpdatePolicyCommandHandler : IRequestHandler<UpdatePolicyCommandRequest, UpdatePolicyCommandResponse>
    {
        private readonly IPolicyWriteRepository _policyWriteRepository;
        private readonly IPolicyReadRepository _policyReadRepository;

        public UpdatePolicyCommandHandler(IPolicyWriteRepository policyWriteRepository, IPolicyReadRepository policyReadRepository)
        {
            _policyWriteRepository = policyWriteRepository;
            _policyReadRepository = policyReadRepository;
        }

        public async Task<UpdatePolicyCommandResponse> Handle(UpdatePolicyCommandRequest request, CancellationToken cancellationToken)
        {
            var policy = await  _policyReadRepository.GetByIdAsync(request.Id);
            policy.PolicyName = request.PolicyName;
            policy.PolicyDescription = request.PolicyDescription;
            policy.PolicyIcon = request.PolicyIcon;
            policy.PolicyTabHref = request.PolicyTabHref;
            await _policyWriteRepository.SaveAsync();
            return new();
        }
    }
}
