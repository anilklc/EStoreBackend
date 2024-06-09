using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.ProductImage
{
    public class ListProductImage
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
