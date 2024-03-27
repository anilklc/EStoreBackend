using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.BrandImage
{
    public class ListBrandWithBrandImage
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string BrandImageId { get; set; }
        public string BrandName { get; set; }
    }
}
