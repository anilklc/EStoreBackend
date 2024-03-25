using EStoreBackend.Application.Features.Commands.Policy.Rules;
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
        private readonly IPolicyReadRepository _policyReadRepository;
        private readonly PolicyRules _policyRules;
        public CreatePolicyCommandHandler(IPolicyWriteRepository policyWriteRepository, IPolicyReadRepository policyReadRepository, PolicyRules policyRules)
        {
            _policyWriteRepository = policyWriteRepository;
            _policyReadRepository = policyReadRepository;
            _policyRules = policyRules;
        }

        public async Task<CreatePolicyCommandResponse> Handle(CreatePolicyCommandRequest request, CancellationToken cancellationToken)
        {
            var policy = _policyReadRepository.GetAll().ToList();
            await _policyRules.PolicyTitleMustNotBeSame(policy,request.PolicyName);
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
