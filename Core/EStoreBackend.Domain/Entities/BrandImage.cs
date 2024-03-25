using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class BrandImage : BaseEntity
    {
        public string ImagePath { get; set; }

        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
