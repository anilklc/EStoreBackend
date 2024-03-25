using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Policy.CreatePolicy
{
    public class CreatePolicyCommandValidator : AbstractValidator<CreatePolicyCommandRequest>
    {
        public CreatePolicyCommandValidator() 
        {
            RuleFor(p => p.PolicyName).NotNull().NotEmpty().MinimumLength(5).WithName("Policy");
        }

    }
}
