﻿using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public string ProductCoverImagePath { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
    }
}
