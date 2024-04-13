using EStoreBackend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public string ProductSize { get; set; }
        public int ProductStock {  get; set; }
        public Guid ProductId { get; set; }
    }
}
