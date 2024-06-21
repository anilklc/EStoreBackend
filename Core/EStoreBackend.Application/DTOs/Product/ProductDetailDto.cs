using EStoreBackend.Application.DTOs.ProductImage;
using EStoreBackend.Application.DTOs.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.Product
{
    public class ProductDetailDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public string ProductCoverImage { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
        public List<StockDto> Stock { get; set; }
    }
}
