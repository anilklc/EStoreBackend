using EStoreBackend.Application.Bases;
using EStoreBackend.Application.Features.Commands.Policy.Exceptions;
using EStoreBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Policy.Rules
{
    public class PolicyRules : BaseRules
    {
        public Task PolicyTitleMustNotBeSame(IList<Domain.Entities.Policy> policy, string requestName)
        {
            if (policy.Any(p => p.PolicyName == requestName)) throw new PolicyTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
        

    }
}
