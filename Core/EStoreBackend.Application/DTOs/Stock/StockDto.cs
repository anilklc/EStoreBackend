using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreBackend.Application.DTOs.Stock
{
    public class StockDto
    {
        public string Id { get; set; }
        public string ProductSize { get; set; }
        public int ProductStock { get; set; }
    }
}
