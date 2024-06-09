﻿using EStoreBackend.Application.DTOs.Product;

namespace EStoreBackend.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public List<GetAllProductDto> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}