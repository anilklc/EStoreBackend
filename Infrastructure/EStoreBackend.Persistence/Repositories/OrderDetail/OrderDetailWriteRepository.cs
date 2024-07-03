using EStoreBackend.Application.Interfaces.Repositories;
using EStoreBackend.Domain.Entities;
using EStoreBackend.Persistence.Context;

namespace EStoreBackend.Persistence.Repositories
{
    public class OrderDetailWriteRepository : WriteRepository<OrderDetail>, IOrderDetailWriteRepository
    {
        public OrderDetailWriteRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}
