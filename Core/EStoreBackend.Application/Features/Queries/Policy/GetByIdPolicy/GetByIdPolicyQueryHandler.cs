using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Policy.GetByIdPolicy
{
    public class GetByIdPolicyQueryHandler : IRequestHandler<GetByIdPolicyQueryRequest, GetByIdPolicyQueryResponse>
    {
        private readonly IPolicyReadRepository _policyReadRepository;

        public GetByIdPolicyQueryHandler(IPolicyReadRepository policyReadRepository)
        {
            _policyReadRepository = policyReadRepository;
        }

        public async Task<GetByIdPolicyQueryResponse> Handle(GetByIdPolicyQueryRequest request, CancellationToken cancellationToken)
        {
            var policy = await _policyReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = request.Id,
                PolicyName = policy.PolicyName,
                PolicyDescription = policy.PolicyDescription,
                PolicyIcon = policy.PolicyIcon,
                PolicyTabHref = policy.PolicyTabHref
            };
        }
    }
}
