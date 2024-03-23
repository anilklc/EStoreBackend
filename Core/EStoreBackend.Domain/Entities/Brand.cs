using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }
        public string BrandImageUrl { get; set; }
    }
}
