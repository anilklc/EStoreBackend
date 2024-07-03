using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
