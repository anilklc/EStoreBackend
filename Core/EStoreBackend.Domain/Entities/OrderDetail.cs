﻿using EStoreBackend.Domain.Common;
using System.Text.Json.Serialization;

namespace EStoreBackend.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public Order Order { get; set; }
    }
}
