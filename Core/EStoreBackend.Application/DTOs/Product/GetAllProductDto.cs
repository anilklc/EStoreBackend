using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.Product
{
    public class GetAllProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string CoverImagePath { get; set; } 

    }
}
