using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class ReviewImage : BaseEntity
    {
        public string ImagePath { get; set; }

        [ForeignKey("Review")]
        public Guid ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
