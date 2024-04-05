using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class SliderImage : BaseEntity
    {
        public string ImagePath { get; set; }

        [ForeignKey("Slider")]
        public Guid SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
