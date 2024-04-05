using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string ReviewerName { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewComment { get; set; }
        public ICollection<ReviewImage> ReviewImages { get; set; }

    }
}
