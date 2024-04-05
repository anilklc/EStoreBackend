using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.SliderImage
{
    public class ListSliderWithSliderImage
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderSubtitle { get; set; }
        public string SliderTargetUrl { get; set; }
        public bool SliderActive { get; set; }
       
    }
}
