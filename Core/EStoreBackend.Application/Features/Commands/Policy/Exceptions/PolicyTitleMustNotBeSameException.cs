using EStoreBackend.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.Features.Commands.Policy.Exceptions
{
    public class PolicyTitleMustNotBeSameException : BaseExceptions
    {
        public PolicyTitleMustNotBeSameException() :base("This policy has been added before") { }
    }
}
