﻿using EStoreBackend.Domain.Entities;

namespace EStoreBackend.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public string ProductCoverImagePath { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
       
       
    }
}