using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Footer : BaseEntity
    {
        public string FooterAddress { get; set; }
        public string FooterPhone { get; set; }
        public string FooterEmail { get; set; }
    }
}
