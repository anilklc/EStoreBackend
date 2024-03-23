using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Feature : BaseEntity
    {
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureIcon { get; set; }
    }
}
