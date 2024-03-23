using EStoreBackend.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Queries.Policy.GetAllPolicy
{
    public class GetAllPolicyQueryHandler : IRequestHandler<GetAllPolicyQueryRequest, GetAllPolicyQueryResponse>
    {
        private readonly IPolicyReadRepository _policyReadRepository;

        public GetAllPolicyQueryHandler(IPolicyReadRepository policyReadRepository)
        {
            _policyReadRepository = policyReadRepository;
        }

        public async Task<GetAllPolicyQueryResponse> Handle(GetAllPolicyQueryRequest request, CancellationToken cancellationToken)
        {
            var policies = _policyReadRepository.GetAll(false).ToList();

            return new()
            {
                Policies = policies,
            };
        }
    }
}
