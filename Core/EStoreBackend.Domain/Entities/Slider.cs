﻿using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Slider : BaseEntity
    {
        public string SliderTitle { get; set; }
        public string SliderSubtitle { get; set; }
        public ICollection<SliderImage> SliderImages { get; set; }
        public string SliderTargetUrl { get; set; }
        public bool SliderActive { get; set; }
    }
}
