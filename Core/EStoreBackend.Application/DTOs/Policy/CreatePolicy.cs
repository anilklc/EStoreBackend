using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.Policy
{
    public class CreatePolicy
    {
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public string PolicyIcon { get; set; }
        public string PolicyTabHref { get; set; }
    }
}
