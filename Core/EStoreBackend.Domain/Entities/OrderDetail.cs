using EStoreBackend.Domain.Common;

namespace EStoreBackend.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
